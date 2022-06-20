using MIS.Domain.Entities;
using MIS.Shared.Interfaces;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Repositories
{
    public interface IStudentGroupHistoryRepository : IRepository<StudentGroupHistory>
    {
        Task AddHistory(int studentId, int groupId, int courseId);
    }
}
