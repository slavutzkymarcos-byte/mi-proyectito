using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Permiso
    {
        [Key]
        public int Id { get; set; }
        
        public int UsuarioId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Modulo { get; set; } = string.Empty;
        
        public bool Crear { get; set; }
        public bool Leer { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Exportar { get; set; }
    }
}
