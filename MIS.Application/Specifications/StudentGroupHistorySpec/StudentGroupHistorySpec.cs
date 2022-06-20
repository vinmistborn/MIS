using Ardalis.Specification;
using MIS.Domain.Entities;

namespace MIS.Application.Specifications.StudentGroupHistorySpec
{
    public class StudentGroupHistorySpec : Specification<StudentGroupHistory>, ISingleResultSpecification
    {
        public StudentGroupHistorySpec()
        {
            Query.
                 Include(p => p.Student)
                .Include(p => p.Group);
        }

        public StudentGroupHistorySpec(int studentId, int groupId) : this()
        {
            Query              
                .Where( p => p.StudentId == studentId
                        && p.GroupId == groupId);
        }

        public StudentGroupHistorySpec(int studentId) : this()
        {
            Query              
                .Where(p => p.StudentId == studentId);
        }
    }
}
