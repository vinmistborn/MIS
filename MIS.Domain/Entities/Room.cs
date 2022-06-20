using MIS.Shared;

namespace MIS.Domain.Entities
{
    public class Room :BaseEntity
    {        
        public string Code { get; set; }
        public int Capacity { get; set; }       
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
    }



    
}
