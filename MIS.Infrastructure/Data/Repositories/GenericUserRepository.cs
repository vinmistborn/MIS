using MIS.Domain.Entities.Identity;
using MIS.Application.Specifications.UserSpec;
using System.Collections.Generic;
using System.Threading.Tasks;
using MIS.Shared.Interfaces.Repositories;

namespace MIS.Infrastructure.Data.Repositories
{
    public class GenericUserRepository<T> : Repository<T>, IGenericUserRepository<T> where T : User
    {
        public GenericUserRepository(AppDbContext context): base(context)
        {

        }
        public async Task<IEnumerable<T>> GetUsersOnLeaveAsync()
        {
            return await base.ListAsync(new UserOnLeaveStatusSpec<T>());
        }

        public async Task<IEnumerable<T>> GetUsersQuitAsync()
        {
            return await base.ListAsync(new UsersQuitStatusSpec<T>());
        }
    }
}
