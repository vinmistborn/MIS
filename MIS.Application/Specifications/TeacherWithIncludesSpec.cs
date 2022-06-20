using Ardalis.Specification;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using System.Linq;

namespace MIS.Application.Specifications
{
   public class TeacherWithIncludesSpec : Specification<Teacher>, ISingleResultSpecification
    {
        public TeacherWithIncludesSpec()
        {
            Query
                .Include(p => p.Groups)
                .Include(p => p.Branch)
                .Where(p => p.EmployeeStatus == EmployeeStatus.Active);
        }

        public TeacherWithIncludesSpec(int id) : this()
        {
            Query
                .Where(p => p.Id == id);
        }
    }
}
