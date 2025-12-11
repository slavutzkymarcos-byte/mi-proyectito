using System;
using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Hito
    {
        [Key]
        public int Id { get; set; }
        
        public int ProyectoId { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        public DateTime FechaObjetivo { get; set; }
        public DateTime? FechaCompletado { get; set; }
        
        public bool Completado { get; set; }
        
        [MaxLength(500)]
        public string? Descripcion { get; set; }
    }
}
