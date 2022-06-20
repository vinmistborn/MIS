using System;

namespace MIS.Application.DTOs.CashFlowBase
{
    public class CashFlowBaseInfoDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public string Comment { get; set; }
        public string Branch { get; set; }
    }
}
