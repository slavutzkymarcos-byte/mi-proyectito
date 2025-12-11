using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Wpf.Models
{
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        [MaxLength(1000)]
        public string? Objetivos { get; set; }
        
        [MaxLength(1000)]
        public string? Alcance { get; set; }
        
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        
        public decimal Presupuesto { get; set; }
        public decimal GastosActuales { get; set; }
        
        public EstadoProyecto Estado { get; set; }
        public int Prioridad { get; set; } = 3;
        
        public int GerenteId { get; set; }
        public Usuario? Gerente { get; set; }
        
        public List<Tarea> Tareas { get; set; } = new();
        public List<Recurso> Recursos { get; set; } = new();
        public List<Riesgo> Riesgos { get; set; } = new();
        public List<Hito> Hitos { get; set; } = new();
        
        [MaxLength(2000)]
        public string? Notas { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }

    public enum EstadoProyecto
    {
        Planificacion,
        EnProgreso,
        EnPausa,
        Completado,
        Cancelado
    }
}
