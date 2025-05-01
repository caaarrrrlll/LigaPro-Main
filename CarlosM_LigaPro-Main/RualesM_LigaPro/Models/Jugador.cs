using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarlosM_LigaPro.Models
{
    public class Jugador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Nombre del Jugador")]
        public string Nombre { get; set; } = string.Empty;

        [Range(1, 99)]
        [DisplayName("Número de Camiseta")]
        public int NumeroCamiseta { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Goles")]
        public int Goles { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Asistencias")]
        public int Asistencias { get; set; }

        [Range(0, double.MaxValue)]

        [DisplayName("Sueldo")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Sueldo { get; set; }

        [Required]
        public int EquipoId { get; set; }
        public Equipo? Equipo { get; set; }
    }
}
