using System;
using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        [MaxLength(1000)]
        public string? Descripcion { get; set; }
        
        public int ProyectoId { get; set; }
        public Proyecto? Proyecto { get; set; }
        
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        
        public int DuracionDias { get; set; }
        
        public EstadoTarea Estado { get; set; }
        
        public int PorcentajeCompletado { get; set; }
        
        public PrioridadTarea Prioridad { get; set; }
        
        public int? AsignadoAId { get; set; }
        public Usuario? AsignadoA { get; set; }
        
        public decimal CostoEstimado { get; set; }
        public decimal CostoReal { get; set; }
        
        [MaxLength(500)]
        public string? DependeDe { get; set; }
        
        [MaxLength(1000)]
        public string? Notas { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }

    public enum EstadoTarea
    {
        Pendiente,
        EnProgreso,
        EnRevision,
        Completada,
        Bloqueada
    }

    public enum PrioridadTarea
    {
        MuyBaja = 1,
        Baja = 2,
        Media = 3,
        Alta = 4,
        Critica = 5
    }
}
