using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Controllers;

[Authorize(Policy = "HasAccess")]
[Route("[controller]")]
public class WebinarsController : Controller
{
    public readonly UserManager<UserEntity> _userManager;
    public WebinarsController(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IActionResult> Index()
    {
        return Inertia.Render("Webinars/Index");
    }
}
