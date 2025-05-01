using Microsoft.EntityFrameworkCore;
using CarlosM_LigaPro.Models;

namespace CarlosM_LigaPro.Data
{
    public class LigaProDbContext : DbContext
    {
        public LigaProDbContext(DbContextOptions<LigaProDbContext> options) : base(options) { }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>()
                .HasOne(j => j.Equipo)
                .WithMany(e => e.Jugadores)
                .HasForeignKey(j => j.EquipoId);
        }
    }
}

