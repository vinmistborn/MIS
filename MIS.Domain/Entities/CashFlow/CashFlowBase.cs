using MIS.Domain.Enums;
using MIS.Shared;
using System;

namespace MIS.Domain.Entities.CashFlow
{
   public class CashFlowBase : BaseEntity
    {
        public DateTime Date { get; set; }       
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Comment { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
