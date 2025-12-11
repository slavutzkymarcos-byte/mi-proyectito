using System.Windows;
using GestorProyectos.Wpf.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GestorProyectos.Wpf.Views
{
    public partial class LoginWindow : Window
    {
        private readonly IAuthService _authService;
        private readonly IToastService _toastService;

        public LoginWindow(IAuthService authService, IToastService toastService)
        {
            InitializeComponent();
            _authService = authService;
            _toastService = toastService;

            // Para desarrollo - puedes comentar estas líneas
            txtUsuario.Text = "admin";
            txtPassword.Password = "admin123";
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            var usuario = txtUsuario.Text.Trim();
            var password = txtPassword.Password;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                _toastService.MostrarAdvertencia("Por favor ingrese usuario y contraseña.");
                return;
            }

            if (_authService.IniciarSesion(usuario, password))
            {
                var mainWindow = App.AppHost?.Services.GetRequiredService<MainWindow>();
                if (mainWindow != null)
                {
                    mainWindow.Show();
                    this.Close();
                }
            }
            else
            {
                _toastService.MostrarError("Usuario o contraseña incorrectos.");
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
