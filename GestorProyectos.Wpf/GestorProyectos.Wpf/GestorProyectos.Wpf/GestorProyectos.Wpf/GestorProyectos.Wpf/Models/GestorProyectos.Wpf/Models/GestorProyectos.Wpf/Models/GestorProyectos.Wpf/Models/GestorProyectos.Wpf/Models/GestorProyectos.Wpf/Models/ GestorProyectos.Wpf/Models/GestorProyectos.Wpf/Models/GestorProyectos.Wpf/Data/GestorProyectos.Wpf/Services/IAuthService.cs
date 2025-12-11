using GestorProyectos.Wpf.Models;

namespace GestorProyectos.Wpf.Services
{
    public interface IAuthService
    {
        Usuario? UsuarioActual { get; }
        bool IniciarSesion(string nombreUsuario, string password);
        void CerrarSesion();
        void CrearUsuarioInicialSiNoExiste();
    }
}
