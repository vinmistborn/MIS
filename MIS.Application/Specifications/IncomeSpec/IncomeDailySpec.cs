using Ardalis.Specification;
using MIS.Domain.Entities;
using System;
using System.Linq;

namespace MIS.Application.Specifications.IncomeSpec
{
    public class IncomeDailySpec : Specification<Income>, ISingleResultSpecification
    {
        public IncomeDailySpec()
        {
            Query
                .Include(x => x.Branch)
                .Where(x => x.Date.Date == DateTime.Today.Date);
        }
    }
}
