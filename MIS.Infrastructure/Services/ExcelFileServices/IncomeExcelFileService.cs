using MIS.Application.Interfaces.Services;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using MIS.Application.Specifications.IncomeSpec;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Linq;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace MIS.Infrastructure.Services.ExcelFileServices
{
    public class IncomeExcelFileService : IIncomeExcelFileService
    {
        private readonly IIncomeService _incomeService;

        public IncomeExcelFileService(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        public async Task<MemoryStream> CreateIncomeWorkbook()
        {
            var incomeList = await _incomeService.GetAllEntitiesSpecAsync(new IncomeWithIncludesSpec());

            var stream = new MemoryStream();

            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Income");
                worksheet.Cells["A1"].Value = "№";
                worksheet.Cells["B1"].Value = "Student";
                worksheet.Cells["C1"].Value = "Group";
                worksheet.Cells["D1"].Value = "Amount";
                worksheet.Cells["E1"].Value = "Payment Type";
                worksheet.Cells["F1"].Value = "Date";                
                worksheet.Cells["G1"].Value = "Comment";
                worksheet.Cells["H1"].Value = "Branch";                
                

                int valuesStartRow = 2;
                int incomeNumber = 0;
                foreach (var income in incomeList)
                {
                    worksheet.Cells[valuesStartRow, 1].Value = ++incomeNumber;
                    worksheet.Cells[valuesStartRow, 2].Value = income.Student;
                    worksheet.Cells[valuesStartRow, 3].Value = income.Group;                    
                    worksheet.Cells[valuesStartRow, 4].Value = $"{new RegionInfo("uz-Latn-UZ").ISOCurrencySymbol} {income.Amount.ToString("N", new CultureInfo("en-US"))}";
                    worksheet.Cells[valuesStartRow, 5].Value = income.PaymentType;
                    worksheet.Cells[valuesStartRow, 6].Value = income.Date.ToString("dd/MM/yyyy hh:mm tt");
                    worksheet.Cells[valuesStartRow, 7].Value = income.Comment;
                    worksheet.Cells[valuesStartRow, 8].Value = income.Branch;

                    valuesStartRow++;
                }

                var totalAmount = incomeList.Sum(x => x.Amount).ToString("N", new CultureInfo("en-US"));
                worksheet.Cells[valuesStartRow, 4].Value = $"Total amount: {$"{new RegionInfo("uz-Latn-UZ").ISOCurrencySymbol} {totalAmount}"}";
                worksheet.Cells[valuesStartRow, 4].Style.Font.Bold = true;

                worksheet.View.FreezePanes(2, 1);

                worksheet.Columns.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells.Style.Font.Name = "Arial";
                worksheet.Cells.Style.Font.Size = 10;
                worksheet.Cells.AutoFitColumns();
                worksheet.Cells["A1:H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                worksheet.Cells["A1:H1"].Style.Font.Bold = true;

                
                
                xlPackage.Workbook.Properties.Title = "Income list";                

                xlPackage.Save();
            }

            stream.Position = 0;
            return stream;
        }
    }
}
