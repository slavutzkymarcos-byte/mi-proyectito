using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        
        public RolUsuario Rol { get; set; }
        
        public bool Activo { get; set; } = true;
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        [MaxLength(100)]
        public string? Departamento { get; set; }
        
        [MaxLength(500)]
        public string? Habilidades { get; set; }
        
        public List<Permiso> Permisos { get; set; } = new();
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }

    public enum RolUsuario
    {
        Director,
        GerenteProyecto,
        Miembro,
        Observador
    }
}
