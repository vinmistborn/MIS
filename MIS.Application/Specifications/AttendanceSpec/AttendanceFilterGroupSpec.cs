using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Linq;

namespace MIS.Application.Specifications.AttendanceSpec
{
    public class AttendanceFilterGroupSpec : Specification<Attendance>, ISingleResultSpecification
    {
        public AttendanceFilterGroupSpec(int groupId)
        {
            Query
                .Include(p => p.Student)
                .Include(p => p.Group)
                .Where(p => p.GroupId == groupId);
        }
    }
}
