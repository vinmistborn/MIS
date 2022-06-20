using Ardalis.Specification;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using System.Linq;

namespace MIS.Application.Specifications.AttendanceSpec
{
    public class AttendanceWithIncludesSpec : Specification<Attendance>, ISingleResultSpecification
    {
        public AttendanceWithIncludesSpec()
        {
            Query
                .Include(p => p.Student)
                .Include(p => p.Group);
        }

        public AttendanceWithIncludesSpec(int id) : this()
        {
            Query
                .Where(p => p.Id == id);
        }

        public AttendanceWithIncludesSpec(int studentId, int groupId) : this()
        {
            Query
                .Where(p => p.StudentId == studentId)
                .Where(p => p.GroupId == groupId)
                .Where(p => p.AttendanceStatus == AttendanceStatus.Present)
                .OrderByDescending(p => p.DateTime);
        }
    }
}
