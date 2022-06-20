using Ardalis.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Shared.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        public Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
    }
}
