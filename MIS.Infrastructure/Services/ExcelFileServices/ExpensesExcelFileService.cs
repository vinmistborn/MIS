using MIS.Application.Interfaces.Services;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using MIS.Application.Specifications.ExpensesSpec;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace MIS.Infrastructure.Services.ExcelFileServices
{
    public class ExpensesExcelFileService : IExpensesExcelFileService
    {
        private readonly IExpensesService _expensesService;

        public ExpensesExcelFileService(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        public async Task<MemoryStream> CreateExpensesWorkbook()
        {
            var expensesList = await _expensesService.GetAllEntitiesSpecAsync(new ExpensesWithIncludesSpec());

            var stream = new MemoryStream();

            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Expenses");
                worksheet.Cells["A1"].Value = "№";
                worksheet.Cells["B1"].Value = "Item";                
                worksheet.Cells["C1"].Value = "Amount";
                worksheet.Cells["D1"].Value = "Payment Type";
                worksheet.Cells["E1"].Value = "Date";
                worksheet.Cells["F1"].Value = "Comment";
                worksheet.Cells["G1"].Value = "Branch";


                int valuesStartRow = 2;
                int expenseNumber = 0;
                foreach (var expense in expensesList)
                {
                    worksheet.Cells[valuesStartRow, 1].Value = ++expenseNumber;
                    worksheet.Cells[valuesStartRow, 2].Value = expense.Item;
                    worksheet.Cells[valuesStartRow, 3].Value = $"{new RegionInfo("uz-Latn-UZ").ISOCurrencySymbol} {expense.Amount.ToString("N", new CultureInfo("en-US"))}";
                    worksheet.Cells[valuesStartRow, 4].Value = expense.PaymentType;                    
                    worksheet.Cells[valuesStartRow, 5].Value = expense.Date.ToString("dd/MM/yyyy hh:mm tt");
                    worksheet.Cells[valuesStartRow, 6].Value = expense.Comment;
                    worksheet.Cells[valuesStartRow, 7].Value = expense.Branch;

                    valuesStartRow++;
                }

                var totalAmount = expensesList.Sum(x => x.Amount).ToString("N", new CultureInfo("en-US"));
                worksheet.Cells[valuesStartRow, 3].Value = $"Total amount: {$"{new RegionInfo("uz-Latn-UZ").ISOCurrencySymbol} {totalAmount}"}";
                worksheet.Cells[valuesStartRow, 3].Style.Font.Bold = true;

                worksheet.View.FreezePanes(2, 1);

                worksheet.Columns.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells.Style.Font.Name = "Arial";
                worksheet.Cells.Style.Font.Size = 10;
                worksheet.Cells.AutoFitColumns();
                worksheet.Cells["A1:G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:G1"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                worksheet.Cells["A1:G1"].Style.Font.Bold = true;

                xlPackage.Workbook.Properties.Title = "Expenses list";

                xlPackage.Save();
            }

            stream.Position = 0;
            return stream;
        }
    }
}
