using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using MIS.Shared;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Infrastructure.Data.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
    }
}
