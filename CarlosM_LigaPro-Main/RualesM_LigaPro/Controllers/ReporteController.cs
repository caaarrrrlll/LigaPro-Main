using CarlosM_LigaPro.Data;
using Microsoft.AspNetCore.Mvc;

public class ReporteController : Controller
{
    private readonly LigaProDbContext _context;

    public ReporteController(LigaProDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var topGoleadores = _context.Jugadores
            .OrderByDescending(j => j.Goles)
            .Take(5)
            .ToList();

        var topAsistentes = _context.Jugadores
            .OrderByDescending(j => j.Asistencias)
            .Take(5)
            .ToList();

        var topEquiposPresupuesto = _context.Equipos
            .Select(e => new
            {
                Equipo = e,
                Presupuesto = e.Jugadores.Sum(j => j.Sueldo)
            })
            .OrderByDescending(e => e.Presupuesto)
            .Take(5)
            .ToList();

        ViewBag.TopGoleadores = topGoleadores;
        ViewBag.TopAsistentes = topAsistentes;
        ViewBag.TopEquiposPresupuesto = topEquiposPresupuesto;

        return View();
    }
}

