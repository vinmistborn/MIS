using Ardalis.Specification;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Specifications.TotalCashFlowSpec
{
    public class TotalCashFlowWithBranchSpec : Specification<TotalCashFlow>, ISingleResultSpecification
    {
        public TotalCashFlowWithBranchSpec()
        {
            Query
                .Include(x => x.Branch);
        }
    }
}
