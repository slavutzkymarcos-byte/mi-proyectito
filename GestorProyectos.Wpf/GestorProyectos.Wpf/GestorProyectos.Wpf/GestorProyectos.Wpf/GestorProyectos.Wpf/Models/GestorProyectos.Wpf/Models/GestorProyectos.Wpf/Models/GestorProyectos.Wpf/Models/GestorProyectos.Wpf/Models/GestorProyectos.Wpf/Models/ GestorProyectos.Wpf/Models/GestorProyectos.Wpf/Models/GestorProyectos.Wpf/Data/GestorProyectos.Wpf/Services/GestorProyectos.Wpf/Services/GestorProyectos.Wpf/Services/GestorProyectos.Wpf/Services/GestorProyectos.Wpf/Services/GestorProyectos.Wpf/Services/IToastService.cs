namespace GestorProyectos.Wpf.Services
{
    public interface IToastService
    {
        void MostrarExito(string mensaje);
        void MostrarError(string mensaje);
        void MostrarAdvertencia(string mensaje);
        void MostrarInformacion(string mensaje);
    }
}
