using System;
using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? Empresa { get; set; }
        
        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }
        
        [MaxLength(20)]
        public string? Telefono { get; set; }
        
        [MaxLength(200)]
        public string? Direccion { get; set; }
        
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        
        [MaxLength(1000)]
        public string? Notas { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
