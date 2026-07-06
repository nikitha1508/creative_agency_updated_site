using System.Diagnostics;
using CreativeAgency.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreativeAgency.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("", Name = "home")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("about", Name = "about")]
    public IActionResult About()
    {
        return View();
    }

    [Route("services", Name = "services")]
    public IActionResult Services()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
