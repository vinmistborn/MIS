using MIS.Application.Interfaces.Services;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;

namespace MIS.Infrastructure.Services.ExcelFileServices
{
    public class CashFlowExcelFileService : ICashFlowExcelFileService
    {
        private readonly ICashFlowService _cashFlowService;

        public CashFlowExcelFileService(ICashFlowService cashFlowService)
        {
            _cashFlowService = cashFlowService;
        }

        public async Task<MemoryStream> CreateCashFlowWorkbook()
        {
            var cashFlowList = await _cashFlowService.GetDailyCashFlowAsync();

            var stream = new MemoryStream();

            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("DailyCashFlow");
                worksheet.Cells["A1"].Value = "№";
                worksheet.Cells["B1"].Value = "Branch";
                worksheet.Cells["C1"].Value = "Amount";
                worksheet.Cells["D1"].Value = "Date";                         


                int valuesStartRow = 2;
                int expenseNumber = 0;
                foreach (var expense in cashFlowList)
                {
                    worksheet.Cells[valuesStartRow, 1].Value = ++expenseNumber;
                    worksheet.Cells[valuesStartRow, 2].Value = expense.Branch;
                    worksheet.Cells[valuesStartRow, 3].Value = expense.Amount;                   
                    worksheet.Cells[valuesStartRow, 4].Value = expense.DateTime.ToString("dd/MM/yyyy");                    

                    valuesStartRow++;
                }

                var totalAmount = cashFlowList.Sum(x => x.Amount).ToString("N", new CultureInfo("en-US"));
                worksheet.Cells[valuesStartRow, 3].Value = $"Total amount: {$"{new RegionInfo("uz-Latn-UZ").ISOCurrencySymbol} {totalAmount}"}";
                worksheet.Cells[valuesStartRow, 3].Style.Font.Bold = true;

                worksheet.View.FreezePanes(2, 1);

                worksheet.Columns.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells.Style.Font.Name = "Arial";
                worksheet.Cells.Style.Font.Size = 10;
                worksheet.Cells.AutoFitColumns();
                worksheet.Cells["A1:D1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                worksheet.Cells["A1:D1"].Style.Font.Bold = true;

                xlPackage.Workbook.Properties.Title = "Daily Cashflow list";

                xlPackage.Save();
            }

            stream.Position = 0;
            return stream;
        }
    }
}
