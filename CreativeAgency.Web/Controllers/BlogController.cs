using Microsoft.AspNetCore.Mvc;

namespace CreativeAgency.Web.Controllers;

public class BlogController : Controller
{
    [Route("blog", Name = "blog")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("blog/{slug}", Name = "blog-detail")]
    public IActionResult Detail(string slug)
    {
        ViewBag.Slug = slug;
        return View();
    }
}
