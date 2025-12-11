using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Riesgo
    {
        [Key]
        public int Id { get; set; }
        
        public int ProyectoId { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; } = string.Empty;
        
        public NivelRiesgo Probabilidad { get; set; }
        public NivelRiesgo Impacto { get; set; }
        
        [MaxLength(1000)]
        public string? PlanMitigacion { get; set; }
        
        public int? ResponsableId { get; set; }
        public Usuario? Responsable { get; set; }
        
        public EstadoRiesgo Estado { get; set; }
    }

    public enum NivelRiesgo
    {
        Bajo = 1,
        Medio = 2,
        Alto = 3
    }

    public enum EstadoRiesgo
    {
        Identificado,
        EnMonitoreo,
        Mitigado,
        Ocurrido
    }
}
