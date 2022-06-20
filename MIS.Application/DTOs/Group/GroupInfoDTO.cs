namespace MIS.Application.DTOs.Group
{
    public class GroupInfoDTO
    {
        public int Id { get; set; } 
        public string GroupType { get; set; }
        public string Code { get; set; }
        public decimal Fee { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public string Course { get; set; }
        
    }
}
