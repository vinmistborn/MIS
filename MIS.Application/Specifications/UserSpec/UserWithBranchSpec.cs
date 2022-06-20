using Ardalis.Specification;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Enums;
using System.Linq;

namespace MIS.Application.Specifications.UserSpec
{
    public class UserWithBranchSpec<T> : Specification<T> , ISingleResultSpecification<T> where T : User
    {
        public UserWithBranchSpec()
        {
            Query
                .Include(p => p.Branch)
                .Where(p => p.EmployeeStatus == EmployeeStatus.Active);
        }

        public UserWithBranchSpec(int id) : this()
        {
            Query
                .Where(p => p.Id == id);
        }
    }
}
