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
    [Route("contact")]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ContactFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Build enriched entry with submission timestamp
        var entry = new
        {
            model.FirstName,
            model.LastName,
            model.Email,
            model.EnquiryType,
            model.Summary,
            SubmittedOn = DateTime.Now
        };

        var filePath = Path.Combine(_environment.ContentRootPath, "contacts.json");
        var options = new JsonSerializerOptions { WriteIndented = true };

        List<JsonElement> entries = new();

        if (System.IO.File.Exists(filePath))
        {
            try
            {
                var existingJson = System.IO.File.ReadAllText(filePath);
                entries = JsonSerializer.Deserialize<List<JsonElement>>(existingJson, options)
                          ?? new List<JsonElement>();
            }
            catch
            {
                entries = new List<JsonElement>();
            }
        }

        // Serialize new entry and append
        var entryJson = JsonSerializer.SerializeToElement(entry, options);
        entries.Add(entryJson);

        System.IO.File.WriteAllText(filePath, JsonSerializer.Serialize(entries, options));

        TempData["Success"] = "Enquiry submitted successfully! We will be in touch shortly.";
        return RedirectToAction("Index");
    }
}
