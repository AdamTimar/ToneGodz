using System.Text;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;
using ToneGodzApp.Models;

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
