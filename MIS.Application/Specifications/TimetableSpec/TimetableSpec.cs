using Ardalis.Specification;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Specifications.TimetableSpec
{
    public class TimetableSpec : Specification<Timetable>, ISingleResultSpecification
    {
        public TimetableSpec()
        {
            Query
                .Include(p => p.Room)
                .Include(p => p.Group)
                .Include(p => p.LessonDay)
                .Include(p => p.GroupTime);
        }

        public TimetableSpec(int lessonDayId,
                             int groupTimeId,
                             int roomId) : this()
        {
            Query                
                .Where(p => p.LessonDayId == lessonDayId
                       && p.GroupTimeId == groupTimeId
                       && p.RoomId == roomId);
        }

        public TimetableSpec(int id) : this()
        {
            Query
                .Where(p => p.Id == id);
        }
    }
}
