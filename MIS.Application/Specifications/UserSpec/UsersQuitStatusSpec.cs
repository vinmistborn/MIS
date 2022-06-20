using Ardalis.Specification;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Enums;
using System.Linq;

namespace MIS.Application.Specifications.UserSpec
{
    public class UsersQuitStatusSpec<T> : Specification<T> where T : User
    {
        public UsersQuitStatusSpec()
        {
            Query
                .Where(p => p.EmployeeStatus == EmployeeStatus.Quit);
        }
    }
}
