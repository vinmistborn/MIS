using Ardalis.Specification;
using MIS.Domain.Entities;
using System;
using System.Linq;

namespace MIS.Application.Specifications.ExpensesSpec
{
    public class ExpensesDailySpec : Specification<Expenses>, ISingleResultSpecification
    {
        public ExpensesDailySpec()
        {
            Query
                .Include(x => x.Branch)
                .Where(x => x.Date.Date == DateTime.Today.Date);
        }
    }
}
