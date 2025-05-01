using Microsoft.EntityFrameworkCore;
using CarlosM_LigaPro.Models;

namespace CarlosM_LigaPro.Data
{
    public class LigaProDbContext : DbContext
    {
        public LigaProDbContext(DbContextOptions<LigaProDbContext> options) : base(options) { }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
    }
}
