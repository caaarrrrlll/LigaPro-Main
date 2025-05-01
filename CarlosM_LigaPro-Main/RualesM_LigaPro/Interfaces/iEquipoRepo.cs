using CarlosM_LigaPro.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlosM_LigaPro.Interfaces
{
    public interface iEquipoRepo
    {
        //Codigo propocionado por Copilot
        public async Task<IEnumerable<Equipo>> GetEquiposAsync()
        {
            return await _context.Equipos.Include(e => e.Jugadores).ToListAsync();
        }

        Task<Equipo> GetEquipoByIdAsync(int id);
        Task AddEquipoAsync(Equipo equipo);
        Task UpdateEquipoAsync(Equipo equipo);
        Task DeleteEquipoAsync(int id);
        //Hasta aqui llega.
        List<Equipo> DevuelveListadoEquipos();
        bool CrearEquipo(Equipo equipo);
        bool ActualizarEquipo(Equipo equipoActualizado);
        bool EliminarEquipo();

        public Equipo DevolverInfoEquipo(int Id);
    }
}
