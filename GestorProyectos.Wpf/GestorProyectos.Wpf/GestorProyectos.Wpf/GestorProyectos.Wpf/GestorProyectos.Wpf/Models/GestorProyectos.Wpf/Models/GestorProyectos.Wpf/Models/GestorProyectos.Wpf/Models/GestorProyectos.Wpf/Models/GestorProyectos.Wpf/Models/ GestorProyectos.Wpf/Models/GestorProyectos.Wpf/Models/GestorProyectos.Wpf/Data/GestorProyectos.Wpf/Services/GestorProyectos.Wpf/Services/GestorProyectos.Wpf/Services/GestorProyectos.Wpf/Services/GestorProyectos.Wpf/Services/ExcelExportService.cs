using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace GestorProyectos.Wpf.Services
{
    public class ExcelExportService : IExcelExportService
    {
        public ExcelExportService()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public byte[] ExportarAExcel<T>(IEnumerable<T> datos, string nombreHoja = "Datos")
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add(nombreHoja);

            var propiedades = typeof(T).GetProperties();
            
            // Headers
            for (int i = 0; i < propiedades.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = propiedades[i].Name;
                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
            }

            // Datos
            var listadatos = datos.ToList();
            for (int row = 0; row < listadatos.Count; row++)
            {
                for (int col = 0; col < propiedades.Length; col++)
                {
                    var valor = propiedades[col].GetValue(listadatos[row]);
                    worksheet.Cells[row + 2, col + 1].Value = valor;
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            return package.GetAsByteArray();
        }

        public void GuardarArchivo(byte[] datos, string rutaArchivo)
        {
            File.WriteAllBytes(rutaArchivo, datos);
        }
    }
}
