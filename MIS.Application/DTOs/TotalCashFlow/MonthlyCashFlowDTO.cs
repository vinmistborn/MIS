namespace MIS.Application.DTOs.TotalCashFlow
{
    public class MonthlyCashFlowDTO : TotalCashFlowBaseDTO
    {
        public int Year { get; set; }
        public string Month { get; set; }
    }
}
