using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToneGodzApp.Data.Models;

namespace ToneGodzApp.Controllers;

[AllowAnonymous]
public class PluginController : Controller
{
    public readonly UserManager<UserEntity> _userManager;
    public PluginController(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }
    [HttpGet("plugin")]
    public async Task<IActionResult> Index()
    {
        // if (!User.Identity.IsAuthenticated)
        // {
        //     return Inertia.Render("Home/Index");
        // }
        // var user = await _userManager.GetUserAsync(User);
        // if (_userManager.IsInRoleAsync(user, "Admin").Result)
        // {
        //     return RedirectToAction("Index", "Admin");
        // }
        // return Inertia.Render("Home/Index");
        return Inertia.Render("Plugin/Index");
    }
}
