using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Shared.Interfaces.Repositories
{
    public interface IGenericUserRepository<T> : IRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetUsersOnLeaveAsync();
        Task<IEnumerable<T>> GetUsersQuitAsync();
    }
}
