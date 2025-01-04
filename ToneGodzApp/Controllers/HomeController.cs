using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToneGodzApp.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    [HttpGet("/")]
    public async Task<IActionResult> Index()
    {
        return Inertia.Render("Home/Index");
    }
}
