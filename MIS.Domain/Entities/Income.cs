using MIS.Domain.Entities.CashFlow;

namespace MIS.Domain.Entities
{
    public class Income : CashFlowBase
    {
        public int? StudentId { get; set; } 
        public Student Student { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
