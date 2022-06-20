using MIS.Domain.Entities;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Repositories
{
    public interface ITimetableRepository : IRepository<Timetable>
    {
        Task<IEnumerable<Timetable>> GetTimetablesByIdsAsync(IEnumerable<Timetable> timetables);
    }
}
