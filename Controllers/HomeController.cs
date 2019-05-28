using System.Diagnostics;
using LigaDaJustica.Data;
using LigaDaJustica.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace template.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => RedirectToAction("Index", "SuperHerois");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
