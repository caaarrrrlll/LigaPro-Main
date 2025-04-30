using CarlosM_LigaPro.Models;

namespace CarlosM_LigaPro.Interfaces
{
    public interface iEquipoRepo
    {
        List<Equipo> DevuelveListadoEquipos();
        bool CrearEquipo(Equipo equipo);
        bool ActualizarEquipo(Equipo equipoActualizado);
        bool EliminarEquipo();

        public Equipo DevolverInfoEquipo(int Id);
    }
}
