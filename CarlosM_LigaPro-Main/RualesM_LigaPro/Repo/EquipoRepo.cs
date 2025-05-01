using CarlosM_LigaPro.Data;
using CarlosM_LigaPro.Interfaces;
using CarlosM_LigaPro.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlosM_LigaPro.Repo
{
    
    public class EquipoRepo : iEquipoRepo
    {
        
        public static List<Equipo> Equipos = new List<Equipo>
        {
             new Equipo
            {
                Id = 1,
                Nombre = "LDU",
                Logo = "https://upload.wikimedia.org/wikipedia/commons/e/e0/Liga_Deportiva_Universitaria_de_Quito.png",
                Descripcion = "Liga de Quito",
                partidosGanados = 10,
                partidosPerdidos = 0,
                partidosEmpatados = 5
            },
             new Equipo
            {
                Id = 2,
                Nombre = "BSC",
                Logo = "https://a.espncdn.com/i/teamlogos/soccer/500/2686.png",
                Descripcion = "Barcelona SC",
                partidosGanados = 1,
                partidosPerdidos = 8,
                partidosEmpatados = 1
            },
                new Equipo
                {
                    Id = 3,
                    Nombre = "El Nacional",
                    Logo = "https://upload.wikimedia.org/wikipedia/en/7/7f/El_nacional_quito.png",
                    Descripcion = "El Nacional",
                    partidosGanados = 2,
                    partidosPerdidos = 8,
                    partidosEmpatados = 5
                }

        };

        public bool ActualizarEquipo(Equipo equipo)
        {
            if (equipo != null)
            {
                var equipoActualizado = Equipos.Where(item => item.Id == equipo.Id).First();
                equipoActualizado.partidosGanados = equipo.partidosGanados;
                equipoActualizado.partidosPerdidos = equipo.partidosPerdidos;
                equipoActualizado.partidosEmpatados = equipo.partidosEmpatados;
                return true;
            }
            return false;
        }

        private readonly LigaProDbContext _context;
        
        public bool CrearEquipo(Equipo equipo)
        {

            throw new NotImplementedException();
        }

        public Equipo DevolverInfoEquipo(int Id)
        {
            var equipo = Equipos.Where(item => item.Id == Id).First();
            return equipo;
        }

        public List<Equipo> DevuelveListadoEquipos()
        {
            return Equipos.OrderByDescending(item => item.Puntos).ToList();

        }
        public async Task<Equipo> GetEquipoByIdAsync(int id)
        {
            var equipo = await _context.Equipos.Include(e => e.Jugadores).FirstOrDefaultAsync(e => e.Id == id);
            if (equipo == null)
            {
                throw new KeyNotFoundException($"No se encontró un equipo con el ID {id}");
            }
            return equipo;
        }


        public bool EliminarEquipo()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Equipo>> GetEquiposAsync()
        {
            return await _context.Equipos.Include(e => e.Jugadores).ToListAsync();
        }
        public async Task AddEquipoAsync(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEquipoAsync(Equipo equipo)
        {
            _context.Equipos.Update(equipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipoAsync(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
                await _context.SaveChangesAsync();
            }
        }
        public EquipoRepo(LigaProDbContext context)
        {
            _context = context;
        }




    }

}
