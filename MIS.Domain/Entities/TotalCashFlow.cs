using MIS.Shared;
using System;

namespace MIS.Domain.Entities
{
    public class TotalCashFlow : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
