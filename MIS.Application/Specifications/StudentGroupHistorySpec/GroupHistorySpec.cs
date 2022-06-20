using Ardalis.Specification;
using MIS.Domain.Entities;

namespace MIS.Application.Specifications.StudentGroupHistorySpec
{
    public class GroupHistorySpec : Specification<StudentGroupHistory>, ISingleResultSpecification
    {
        public GroupHistorySpec()
        {
            Query
                .Include(p => p.Student)
                .Include(p => p.Group)
                .Where(p => p.IsActive == true);
        }

        public GroupHistorySpec(int groupId) : this()
        {
            Query
                .Where(p => p.GroupId == groupId);
        }

        public GroupHistorySpec(int groupId, int courseId) : this()
        {
            Query
                .Include(p => p.Course)
                .Where(p => p.GroupId == groupId && p.CourseId == courseId);
        }
    }
}
