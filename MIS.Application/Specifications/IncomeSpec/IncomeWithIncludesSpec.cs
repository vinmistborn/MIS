using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Specifications.IncomeSpec
{
    public class IncomeWithIncludesSpec : Specification<Income>, ISingleResultSpecification
    {
        public IncomeWithIncludesSpec()
        {
            Query
                .Include(x => x.Branch)
                .Include(x => x.Student)
                .Include(x => x.Group);
        }

        public IncomeWithIncludesSpec(int id) : this()
        {
            Query
                .Where(x => x.Id == id);
        }
    }
}
