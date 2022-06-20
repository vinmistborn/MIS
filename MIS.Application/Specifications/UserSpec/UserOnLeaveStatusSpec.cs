using Ardalis.Specification;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Enums;
using System.Linq;

namespace MIS.Application.Specifications.UserSpec
{
    public class UserOnLeaveStatusSpec<T> : Specification<T> where T : User
    {
        public UserOnLeaveStatusSpec()
        {
            Query
                .Include(p => p.Branch)
                .Where(p => p.EmployeeStatus == EmployeeStatus.OnLeave);
        }
    }

}
