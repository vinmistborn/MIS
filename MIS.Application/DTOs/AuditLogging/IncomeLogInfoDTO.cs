using MIS.Application.DTOs.Income;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.DTOs.AuditLogging
{
    public class IncomeLogInfoDTO : IncomeInfoDTO
    {
        public string User { get; set; }
        public DateTime EventTime { get; set; }
        public string OperationType { get; set; }
    }
}
