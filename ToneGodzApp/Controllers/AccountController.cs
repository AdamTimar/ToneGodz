using System.Text;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;
using ToneGodzApp.Models;
using ToneGodzApp.Services;

namespace ToneGodzApp.Controllers;

[AllowAnonymous]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly StripeService _stripeService;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMemoryCache _cache;
    private readonly IEmailSenderService _emailSenderService;

    public AccountController(ILogger<HomeController> logger, AppDbContext context,
    SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IMemoryCache cache, IEmailSenderService emailSenderService, StripeService stripeService)
    {
        _logger = logger;
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
        _cache = cache;
        _emailSenderService = emailSenderService;
        _stripeService = stripeService;
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        return Inertia.Render("Account/Login");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel, string returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");

                var hasAccess = await _context.Customers.AnyAsync(x => x.Email == loginModel.Email);
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                _cache.Set($"HasAccess:{user.Id}", hasAccess, TimeSpan.FromHours(1));
                if (returnUrl.ToLower().StartsWith("/admin"))
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("AccessDenied", "Account");
                    }
                }
                return LocalRedirect(returnUrl);
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("message", "Your account has been locked due to too many failed login attempts.");
                }
                else if (result.IsNotAllowed)
                {
                    var user = await _userManager.FindByEmailAsync(loginModel.Email);
                    if (user != null)
                    {
                        if (user.EmailConfirmed == false)
                        {
                            ModelState.AddModelError("message", "Please confirm your email address.");
                        }
                    }
                    ModelState.AddModelError("message", "Your account is not allowed to log in.");
                }
                else if (result.RequiresTwoFactor)
                {
                    ModelState.AddModelError("message", "Two-factor authentication is required.");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt. Please check your email and password.");
                }

                _logger.LogWarning("Failed login attempt for user {Email}", loginModel.Email);
            }
        }
        return Inertia.Render("Account/Login");
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        return Inertia.Render("Account/Register");
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel, string returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        if (ModelState.IsValid)
        {
            var user = new UserEntity { UserName = registerModel.Email, Email = registerModel.Email, CreatedAt = DateTime.Now, TermsOfUseAccepted = true };
            // if (await _context.Customers.FirstOrDefaultAsync(x => x.Email == registerModel.Email) == null)
            // {
            //     ModelState.AddModelError("message", "User with this email hasn't purchased the product yet.");
            //     return Inertia.Render("Account/Register");
            // }

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action(
                    "Confirmation",
                    "Account",
                    new { userId = user.Id, code = code },
                    protocol: Request.Scheme);

                await _emailSenderService.SendMail(registerModel.Email, "Tonegodz.com Account Confirmation", $"<h2>Confirm Your Email Address</h2><p>Please click the link below to confirm your email:</p><a href=\"{callbackUrl}\">Confirm My Email</a>");
                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return RedirectToAction("ConfirmEmail", new { email = registerModel.Email });
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("message", error.Description);
                break;
            }
        }

        return Inertia.Render("Account/Register");
    }

    [HttpGet("ForgotPassword")]
    public IActionResult ForgotPassword()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home"); // Or another page you prefer
        }
        return Inertia.Render("Account/ForgotPassword");
    }


    [HttpGet("AccessDenied")]
    public IActionResult AccessDenied()
    {
        var requestedUrl = HttpContext.Session.GetString("RedirectFromUrl");

        HttpContext.Session.Remove("RedirectFromUrl");

        return Inertia.Render("Account/AccessDenied");
    }

    [HttpGet("ConfirmEmail")]
    public IActionResult ConfirmEmail(string? email)
    {
        return Inertia.Render("Account/ConfirmEmail");
    }

    [HttpGet("CheckInboxPasswordReset")]
    public IActionResult CheckInboxPasswordReset()
    {
        return Inertia.Render("Account/CheckInboxPasswordReset");
    }

    [HttpGet("Confirmation")]
    public async Task<IActionResult> Confirmation(string userId, string code)
    {
        if (userId == null || code == null)
        {
            return BadRequest("User id or confirmation code not set.");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{userId}'.");
        }

        if (user.EmailConfirmed)
        {
            return Inertia.Render("Account/Confirmation",
                                          new { message = "Account is already confirmed." });
        }

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);
        string message = result.Succeeded ? "Your account was confirmed successfully." : "Something went wrong during the confirmation.";

        return Inertia.Render("Account/Confirmation",
                                          new { message = message });
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        try
        {
            await _signInManager.SignOutAsync();

            _logger.LogInformation("User logged out.");

            return Ok(new { message = "Logged out successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging out.");

            return StatusCode(500, new { message = "An error occurred while logging out. Please try again later." });
        }
    }

    [HttpGet("ResendConfirmationEmail")]
    public IActionResult ResendConfirmationEmail()
    {
        return Inertia.Render("Account/ResendConfirmationEmail");
    }

    [HttpPost("ResendConfirmationEmail")]
    public async Task<IActionResult> ResendConfirmationEmail([FromBody] ResendConfirmationEmailModel resendConfirmationEmailModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = ModelState.First().Value.Errors.First().ErrorMessage });
        }
        var user = await _userManager.FindByEmailAsync(resendConfirmationEmailModel.Email);

        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        if (user.EmailConfirmed)
        {
            return Conflict(new { message = "Email is already confirmed." });
        }

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = Url.Action(
            "Confirmation",
            "Account",
            new { userId = user.Id, code = code },
            protocol: Request.Scheme);

        await _emailSenderService.SendMail(resendConfirmationEmailModel.Email, "Tonegodz.com Account Confirmation", $"<h2>Confirm Your Email Address</h2><p>Please click the link below to confirm your email:</p><a href=\"{callbackUrl}\">Confirm My Email</a>");

        return Ok(new { message = "Confirmation email sent." });
    }

    [HttpPost("forgotpassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel forgotPasswordModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
            {
                return Inertia.Render("Account/CheckInboxPasswordReset");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var callbackUrl = Url.Action(
                        "PasswordReset",
                        "Account",
                        new { userId = user.Id, code = code },
                         protocol: Request.Scheme);


            await _emailSenderService.SendMail(forgotPasswordModel.Email, "Update password", $"<h2>Reset your password</h2><p>Please click the link below to reset your password:</p><a href=\"{callbackUrl}\">Reset pasword</a>");

            return Inertia.Render("Account/CheckInboxPasswordReset");
        }
        return Inertia.Render("Account/ForgotPassword");

    }

    [HttpGet("PasswordReset")]
    public async Task<IActionResult> PasswordReset(string userId, string code)
    {
        if (code == null || userId == null)
        {
            return BadRequest("User id or confirmation code not set.");
        }


        var decodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{userId}'.");
        }

        var isValidToken = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", decodedCode);

        if (!isValidToken)
        {
            return BadRequest("Wrong token");
        }

        return Inertia.Render("Account/PasswordReset");
    }

    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
    {
        if (ModelState.IsValid)
        {

            var user = await _userManager.FindByIdAsync(resetPasswordModel.Id);


            var result = await _userManager.ResetPasswordAsync(user, Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPasswordModel.Code)), resetPasswordModel.Password);
            if (result.Succeeded)
            {
                return Inertia.Render("Account/PasswordResetConfirmation");
            }

            return Inertia.Render("Account/PasswordReset", new { message = "Could not reset password." });

        }
        else
        {
            return Inertia.Render("Account/PasswordReset");
        }
    }
}

