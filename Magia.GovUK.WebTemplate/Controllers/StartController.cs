using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Magia.GovUK.WebTemplate.Controllers
{
    public class StartController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View("Magia.GovUK.WebTemplate.Pages.IndexPage");
        }
    }
}
