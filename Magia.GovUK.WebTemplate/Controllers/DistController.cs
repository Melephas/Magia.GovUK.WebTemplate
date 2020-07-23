using Microsoft.AspNetCore.Mvc;

namespace Magia.GovUK.WebTemplate.Controllers
{
    public class DistController : Controller
    {
        public IActionResult GovCss()
        {
            return File(System.IO.File.OpenRead("wwwroot/dist/govuk-frontend-3.5.0.min.css"), "text/css");
        }
    }
}
