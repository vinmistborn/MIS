using Ardalis.Specification;
using MIS.Domain.Entities;

namespace MIS.Application.Specifications.StudentSpec
{
    public class StudentWithGroupSpec : Specification<Student>, ISingleResultSpecification
    {
        public StudentWithGroupSpec()
        {
            Query
                .Include(p => p.Groups)
                .Where(p => p.IsActive == true);
        }

        public StudentWithGroupSpec(int id) : this()
        {
            Query                
                .Where(p => p.Id == id);
        }
    }
}
