namespace MIS.Application.DTOs.Group
{
    public class AddGroupDTO
    {
        public int GroupTypeId { get; set; }
        public string Code { get; set; }
        public int Capacity { get; set; }
        public int CourseId { get; set; }    
    }
}
