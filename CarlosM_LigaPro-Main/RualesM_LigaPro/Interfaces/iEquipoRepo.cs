using CarlosM_LigaPro.Models;

namespace CarlosM_LigaPro.Interfaces
{
    public interface iEquipoRepo
    {
        //Codigo propocionado por Copilot
        Task<IEnumerable<Equipo>> GetEquiposAsync();
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
