using System.IO;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services.ExcelFileServices
{
    public interface IExpensesExcelFileService
    {
        Task<MemoryStream> CreateExpensesWorkbook();
    }
}
