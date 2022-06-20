using Ardalis.Specification;
using MIS.Domain.Entities.AuditLogging;

namespace MIS.Application.Specifications.ExpensesLogSpec
{
    public class ExpensesLogWithIncludesSpec : Specification<ExpensesLog>, ISingleResultSpecification
    {
        public ExpensesLogWithIncludesSpec()
        {
            Query
                .Include(x => x.Branch);
        }

        public ExpensesLogWithIncludesSpec(int id) : this()
        {
            Query
                .Where(x => x.Id == id);                
        }
    }
}
