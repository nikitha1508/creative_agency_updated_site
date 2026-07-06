using System.Text.Json;
using CreativeAgency.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreativeAgency.Web.Controllers;

public class ContactController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public ContactController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    [Route("contact", Name = "contact")]
    public IActionResult Index()
    {
        return View(new ContactFormModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ContactFormModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Message = "Please correct the highlighted fields and try again.";
            return View(model);
        }

        var filePath = Path.Combine(_environment.ContentRootPath, "contacts.json");
        var entries = new List<ContactFormModel>();

        if (System.IO.File.Exists(filePath))
        {
            var existingJson = System.IO.File.ReadAllText(filePath);
            entries = JsonSerializer.Deserialize<List<ContactFormModel>>(existingJson) ?? new List<ContactFormModel>();
        }

        entries.Add(model);
        System.IO.File.WriteAllText(filePath, JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true }));

        ViewBag.Message = "Thanks! Your message has been received and we will be in touch shortly.";
        ModelState.Clear();
        return View(new ContactFormModel());
    }
}
