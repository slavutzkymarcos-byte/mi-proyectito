using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using GestorProyectos.Wpf.Data;
using GestorProyectos.Wpf.Services;

namespace GestorProyectos.Wpf
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiProyectito");
            Directory.CreateDirectory(dataDir);

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(cfg =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((ctx, services) =>
                {
                    var connectionString = $"Data Source={Path.Combine(dataDir, "gestorproyectos.db")}";
                    
                    services.AddDbContext<GestorProyectosContext>(options =>
                        options.UseSqlite(connectionString));

                    services.AddSingleton<IAuthService, AuthService>();
                    services.AddSingleton<IExcelExportService, ExcelExportService>();
                    services.AddSingleton<IToastService, ToastService>();

                    services.AddTransient<Views.LoginWindow>();
                    services.AddTransient<Views.MainWindow>();
                })
                .Build();

            AppHost.Start();

            // Crear base de datos y seed inicial
            using var scope = AppHost.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GestorProyectosContext>();
            db.Database.Migrate();
            
            var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
            authService.CrearUsuarioInicialSiNoExiste();

            var loginWindow = AppHost.Services.GetRequiredService<Views.LoginWindow>();
            loginWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AppHost?.Dispose();
            base.OnExit(e);
        }
    }
}
