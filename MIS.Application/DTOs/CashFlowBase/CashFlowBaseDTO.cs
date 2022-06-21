using MIS.Domain.Enums;

namespace MIS.Application.DTOs.CashFlowBase
{
    public class CashFlowBaseDTO
    {
        public int Id { get; set; }        
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Comment { get; set; }
        public int? BranchId { get; set; }       
    }
}
