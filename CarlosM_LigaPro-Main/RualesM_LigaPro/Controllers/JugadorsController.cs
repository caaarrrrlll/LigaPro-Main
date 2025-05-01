using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarlosM_LigaPro.Data;
using CarlosM_LigaPro.Models;

namespace CarlosM_LigaPro.Controllers
{
    public class JugadorsController : Controller
    {
        private readonly LigaProDbContext _context;

        public JugadorsController(LigaProDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Jugadores.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Equipo");
            }
            ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre", jugador.EquipoId);
            return View(jugador);
        }
    }
}

