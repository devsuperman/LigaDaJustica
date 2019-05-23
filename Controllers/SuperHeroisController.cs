using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LigaDaJustica.Extensions;
using System.Threading.Tasks;
using LigaDaJustica.Models;
using LigaDaJustica.Data;

namespace LigaDaJustica.Controllers
{
    public class SuperHeroisController : Controller
    {
        private readonly Contexto db;

        public SuperHeroisController(Contexto db) => this.db = db;

        public async Task<IActionResult> Index()
        {
            var lista = await db.SuperHerois.ToListAsync();          
            return View(lista);
        }

        public ActionResult Criar() => View();


        [HttpPost]
        public async Task<IActionResult> Criar(SuperHeroi model)
        {                       
            if (ModelState.IsValid)
            {   
                await db.SuperHerois.AddAsync(model);
                await db.SaveChangesAsync();

                this.NotificarSucesso();                          
                
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Editar(int id)
        {        
            var model = await db.SuperHerois.FindAsync(id);

            if (model is null)
                return NotFound();

            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Editar(SuperHeroi model)
        {                       
            if (ModelState.IsValid)
            {
                db.SuperHerois.Update(model);
                await db.SaveChangesAsync();
                this.NotificarSucesso();                          

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {        
            var model = await db.SuperHerois.FindAsync(id);

            if (model is null)
                return NotFound();

            db.SuperHerois.Remove(model);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}