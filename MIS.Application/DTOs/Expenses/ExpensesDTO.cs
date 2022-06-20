using MIS.Application.DTOs.CashFlowBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.DTOs.Expenses
{
    public class ExpensesDTO : CashFlowBaseDTO
    {
        public string Item { get; set; }
    }
}
