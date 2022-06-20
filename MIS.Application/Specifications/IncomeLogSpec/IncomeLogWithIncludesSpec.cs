using Ardalis.Specification;
using MIS.Domain.Entities.AuditLogging;

namespace MIS.Application.Specifications.IncomeLogSpec
{
    public class IncomeLogWithIncludesSpec : Specification<IncomeLog>, ISingleResultSpecification
    {
        public IncomeLogWithIncludesSpec()
        {
            Query
                .Include(x => x.Branch)
                .Include(x => x.Student)
                .Include(x => x.Group);
        }

        public IncomeLogWithIncludesSpec(int id) : this()
        {
            Query
                .Where(x => x.Id == id);
        }
    }
}
