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


[Authorize(Policy = "HasAccess")]
[Route("irpack-drum-sample")]
public class IRPackDrumSampleController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Inertia.Render("IRPackDrumSample/Index");
    }
}