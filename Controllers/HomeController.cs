using System.Diagnostics;
using LigaDaJustica.Data;
using LigaDaJustica.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace template.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto db;

        public HomeController(Contexto db)
        {
            this.db = db;
        }

        public IActionResult Index() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
