using Ardalis.Specification;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using System.Linq;

namespace MIS.Application.Specifications.AttendanceSpec
{
    public class AttendanceFilterStudentSpec : Specification<Attendance>, ISingleResultSpecification
    {
        public AttendanceFilterStudentSpec(int studentId)
        {
            Query
                .Include(p => p.Student)
                .Include(p => p.Group)
                .Where(p => p.StudentId == studentId);
        }

        public AttendanceFilterStudentSpec(int studentId, int groupId) : this(studentId)
        {
            Query
                .Where(p => p.GroupId == groupId)
                .Where(p => p.AttendanceStatus == AttendanceStatus.Present)
                .OrderBy(p => p.DateTime);
        }
    }
}
