using MIS.Domain.Entities;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<IEnumerable<Group>> GetFinishedGroups();
        Task<IEnumerable<Group>> GetTeacherGroups(int teacherId);
        Task<IEnumerable<Group>> GetCourseGroups(int courseId);
    }
}
