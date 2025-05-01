using Microsoft.AspNetCore.Mvc;
using CarlosM_LigaPro.Models;
using CarlosM_LigaPro.Interfaces;

namespace CarlosM_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
        private readonly iEquipoRepo _equipoRepo;

        // Constructor con inyección de dependencias
        public EquipoController(iEquipoRepo equipoRepo)
        {
            _equipoRepo = equipoRepo;
        }

        // Acción para listar los equipos
        public async Task<IActionResult> ListaEquipos()
        {
            var equipos = await _equipoRepo.GetEquiposAsync();
            return View(equipos);
        }

        // Acción para mostrar el formulario de edición
        public async Task<IActionResult> Edit(int id)
        {
            var equipo = await _equipoRepo.GetEquipoByIdAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // Acción para procesar el formulario de edición
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo);
            }

            await _equipoRepo.UpdateEquipoAsync(equipo);
            return RedirectToAction(nameof(ListaEquipos));
        }

        // Acción para mostrar el formulario de creación
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para procesar el formulario de creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo);
            }

            await _equipoRepo.AddEquipoAsync(equipo);
            return RedirectToAction(nameof(ListaEquipos));
        }

        // Acción para eliminar un equipo
        public async Task<IActionResult> Eliminar(int id)
        {
            var equipo = await _equipoRepo.GetEquipoByIdAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // Acción para confirmar la eliminación
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _equipoRepo.DeleteEquipoAsync(id);
            return RedirectToAction(nameof(ListaEquipos));
        }
    }
}


