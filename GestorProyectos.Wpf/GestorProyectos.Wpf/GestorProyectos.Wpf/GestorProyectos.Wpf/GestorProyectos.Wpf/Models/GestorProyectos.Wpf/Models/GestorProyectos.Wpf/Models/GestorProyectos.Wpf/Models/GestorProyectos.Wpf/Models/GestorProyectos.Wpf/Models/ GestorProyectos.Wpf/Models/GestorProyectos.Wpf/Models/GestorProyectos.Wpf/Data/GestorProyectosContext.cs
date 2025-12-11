using Microsoft.EntityFrameworkCore;
using GestorProyectos.Wpf.Models;
using System;
using System.Linq;

namespace GestorProyectos.Wpf.Data
{
    public class GestorProyectosContext : DbContext
    {
        public GestorProyectosContext(DbContextOptions<GestorProyectosContext> options) 
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Riesgo> Riesgos { get; set; }
        public DbSet<Hito> Hitos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones
            modelBuilder.Entity<Proyecto>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proyecto>()
                .HasOne(p => p.Gerente)
                .WithMany()
                .HasForeignKey(p => p.GerenteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Proyecto)
                .WithMany(p => p.Tareas)
                .HasForeignKey(t => t.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.AsignadoA)
                .WithMany()
                .HasForeignKey(t => t.AsignadoAId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Permiso>()
                .HasOne<Usuario>()
                .WithMany(u => u.Permisos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            modelBuilder.Entity<Proyecto>()
                .HasIndex(p => p.Nombre);

            modelBuilder.Entity<Tarea>()
                .HasIndex(t => new { t.ProyectoId, t.FechaFin });
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;
            
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity.GetType().GetProperty("UpdatedAt") != null)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("UpdatedAt").CurrentValue = now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
