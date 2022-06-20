using MIS.Application.DTOs.CashFlowBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.DTOs.Income
{
    public class IncomeDTO : CashFlowBaseDTO
    {
        public int? StudentId { get; set; }
        public int? GroupId { get; set; }   
    }
}
