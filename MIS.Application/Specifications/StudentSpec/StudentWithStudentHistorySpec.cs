using Ardalis.Specification;
using MIS.Domain.Entities;

namespace MIS.Application.Specifications.StudentSpec
{
    public class StudentWithStudentHistorySpec : Specification<Student>, ISingleResultSpecification
    {
        public StudentWithStudentHistorySpec()
        {
            Query
                .Include(p => p.GroupHistory);                
        }
    }
}
