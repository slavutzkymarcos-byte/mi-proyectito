using System.Linq;
using GestorProyectos.Wpf.Data;
using GestorProyectos.Wpf.Models;
using BCrypt.Net;

namespace GestorProyectos.Wpf.Services
{
    public class AuthService : IAuthService
    {
        private readonly GestorProyectosContext _context;

        public AuthService(GestorProyectosContext context)
        {
            _context = context;
        }

        public Usuario? UsuarioActual { get; private set; }

        public bool IniciarSesion(string nombreUsuario, string password)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Activo);

            if (usuario == null)
                return false;

            if (!BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash))
                return false;

            UsuarioActual = usuario;
            return true;
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public void CrearUsuarioInicialSiNoExiste()
        {
            if (!_context.Usuarios.Any())
            {
                var admin = new Usuario
                {
                    NombreUsuario = "admin",
                    NombreCompleto = "Administrador",
                    Email = "admin@miproyectito.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Rol = RolUsuario.Director,
                    Activo = true
                };

                _context.Usuarios.Add(admin);
                _context.SaveChanges();
            }
        }
    }
}
