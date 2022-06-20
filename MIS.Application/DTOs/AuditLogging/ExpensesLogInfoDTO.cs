using MIS.Application.DTOs.Expenses;
using System;

namespace MIS.Application.DTOs.AuditLogging
{
    public class ExpensesLogInfoDTO : ExpensesInfoDTO
    {
        public string User { get; set; }
        public DateTime EventTime { get; set; }
        public string OperationType { get; set; }
    }
}
