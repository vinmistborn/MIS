using MIS.Application.Interfaces.Repositories;
using MIS.Application.Specifications.TimetableSpec;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Infrastructure.Data.Repositories
{
    public class TimetableRepository :Repository<Timetable>, ITimetableRepository
    {
        public TimetableRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Timetable>> GetTimetablesByIdsAsync(IEnumerable<Timetable> timetables)
        {
            ICollection<Timetable> slots = new List<Timetable>();

            foreach (var timetable in timetables)
            {
                var slot = await base.GetBySpecAsync(new TimetableSpec(timetable.Id));
                slots.Add(slot);
            }

            return slots;
        }
    }
}
