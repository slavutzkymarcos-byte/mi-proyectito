using System.Collections.Generic;

namespace GestorProyectos.Wpf.Services
{
    public interface IExcelExportService
    {
        byte[] ExportarAExcel<T>(IEnumerable<T> datos, string nombreHoja = "Datos");
        void GuardarArchivo(byte[] datos, string rutaArchivo);
    }
}
