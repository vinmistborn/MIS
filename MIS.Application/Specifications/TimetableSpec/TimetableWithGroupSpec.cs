using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Linq;

namespace MIS.Application.Specifications.TimetableSpec
{
    public class TimetableWithGroupSpec : Specification<Timetable>, ISingleResultSpecification
    {
        public TimetableWithGroupSpec()
        {
            Query
              .Include(p => p.Room)
              .Include(p => p.Group)
              .Include(p => p.LessonDay)
              .Include(p => p.GroupTime);
        }

        public TimetableWithGroupSpec(int lessonDayId,
                             int groupTimeId) : this()
        {
            Query
                .Where(p => p.LessonDayId == lessonDayId
                        && p.GroupTimeId == groupTimeId
                        && p.Group != null);
        }

        public TimetableWithGroupSpec(int groupId) : this()
        {
            Query
                .Include(x => x.Group.Course)
                .Include(x => x.Group.Teachers)
                .Where(p => p.GroupId == groupId);
        }
    }
}
