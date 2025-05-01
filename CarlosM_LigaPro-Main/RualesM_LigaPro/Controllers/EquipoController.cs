using Microsoft.AspNetCore.Mvc;
using CarlosM_LigaPro.Models;
using CarlosM_LigaPro.Interfaces;

namespace CarlosM_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
        private readonly iEquipoRepo _equipoRepo;

        public EquipoController(iEquipoRepo equipoRepo)
        {
            _equipoRepo = equipoRepo;
        }

        public async Task<IActionResult> ListaEquipos()
        {
            var equipos = await _equipoRepo.GetEquiposAsync();
            var equiposOrdenados = equipos.OrderByDescending(e => e.Puntos).ToList();
            return View(equiposOrdenados);
        }

        public async Task<IActionResult> TablasPosicion()
        {
            var equipos = await _equipoRepo.GetEquiposAsync();
            return View(equipos);
        }
    }
}



