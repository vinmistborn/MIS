using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Linq;

namespace MIS.Application.Specifications.GroupSpec
{
    public class GroupWithCourseFilterSpec : Specification<Group>, ISingleResultSpecification
    {
        public GroupWithCourseFilterSpec(int courseId)
        {
            Query
                .Include(p => p.Course)
                .Include(p => p.Teachers)
                .Where(p => p.CourseId == courseId);
        }
    }
}
