using MIS.Domain.Entities.CashFlow;
using MIS.Domain.Enums;
using System;

namespace MIS.Domain.Entities.AuditLogging
{
    public class IncomeLog : CashFlowBase
    {
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public string User { get; set; }
        public DateTime EventTime { get; set; }
        public OperationType OperationType { get; set; }
    }
}
