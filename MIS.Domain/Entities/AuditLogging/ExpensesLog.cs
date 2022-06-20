using MIS.Domain.Entities.CashFlow;
using MIS.Domain.Enums;
using System;

namespace MIS.Domain.Entities.AuditLogging
{
    public class ExpensesLog : CashFlowBase
    {
        public string Item { get; set; }
        public string User { get; set; }
        public DateTime EventTime { get; set; }
        public OperationType OperationType { get; set; }
    }
}
