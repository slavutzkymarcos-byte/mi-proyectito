using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Recurso
    {
        [Key]
        public int Id { get; set; }
        
        public int ProyectoId { get; set; }
        
        public TipoRecurso Tipo { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        public decimal CostoUnitario { get; set; }
        
        public int CantidadDisponible { get; set; }
        public int CantidadAsignada { get; set; }
        
        [MaxLength(500)]
        public string? Descripcion { get; set; }
    }

    public enum TipoRecurso
    {
        Humano,
        Financiero,
        Material,
        Software,
        Equipo
    }
}
