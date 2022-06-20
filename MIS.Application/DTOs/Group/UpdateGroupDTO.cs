namespace MIS.Application.DTOs.Group
{
    public class UpdateGroupDTO
    {
        public int Id { get; set; }
        public int GroupTypeId { get; set; }
        public string Code { get; set; }
        public int Capacity { get; set; }
    }
}
