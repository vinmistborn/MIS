using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Linq;

namespace MIS.Application.Specifications.GroupSpec
{
    public class GroupWithTeacherFilterSpec : Specification<Group>, ISingleResultSpecification
    {
        public GroupWithTeacherFilterSpec(Teacher teacher)
        {
            Query
                .Include(p => p.Teachers)
                .Include(p => p.Course)
                .Include(p => p.GroupType)
                .Where(p => p.Teachers.Contains(teacher));
        }
    }
}
