using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Linq;

namespace MIS.Application.Specifications.StudentSpec
{
   public class StudentIsActiveFalseSpec : Specification<Student>
    {
        public StudentIsActiveFalseSpec()
        {
            Query
                .Where(p => p.IsActive == false);
        }
    }
}
