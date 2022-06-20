using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Linq;

namespace MIS.Application.Specifications.ExpensesSpec
{
    public class ExpensesWithIncludesSpec : Specification<Expenses>, ISingleResultSpecification
    {
        public ExpensesWithIncludesSpec()
        {
            Query
                .Include(x => x.Branch);
        }

        public ExpensesWithIncludesSpec(int id) : this()
        {
            Query
                .Where(x => x.Id == id);
        }
    }
}
