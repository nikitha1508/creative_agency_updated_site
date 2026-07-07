using Microsoft.AspNetCore.Mvc;

namespace CreativeAgency.Web.Controllers;

public class BlogController : Controller
{
    [Route("blog")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("blog/{slug}")]
    public IActionResult Detail(string slug)
    {
        switch (slug)
        {
            case "10-tips-for-a-successful-business":

                ViewBag.Title = "10 Tips for a Successful Business";
                ViewBag.Author = "Admin";
                ViewBag.Date = "May 20, 2026";
                ViewBag.Image = "blog1.jpg";

                ViewBag.Content = @"
A successful business is built on planning, innovation, and customer satisfaction.

Here are ten practical tips to help your business grow.

1. Understand your customers and their needs.
2. Build a professional website.
3. Invest in quality branding.
4. Improve your SEO strategy.
5. Stay active on social media.
6. Deliver excellent customer service.
7. Monitor your business performance regularly.
8. Keep learning new technologies.
9. Build a strong and motivated team.
10. Continuously improve your products and services.";

                break;

            case "how-to-improve-seo":

                ViewBag.Title = "How to Improve Your Website SEO";
                ViewBag.Author = "Admin";
                ViewBag.Date = "May 18, 2026";
                ViewBag.Image = "blog2.jpg";

                ViewBag.Content = @"
Search Engine Optimization (SEO) helps your website rank higher in search engine results.

Here are some effective SEO practices:

• Publish high-quality content.
• Use relevant keywords naturally.
• Optimize page titles and meta descriptions.
• Improve website loading speed.
• Make your website mobile-friendly.
• Add descriptive image alt text.
• Build quality backlinks.
• Update your content regularly.";

                break;

            default:
                return NotFound();
        }

        return View();
    }
}