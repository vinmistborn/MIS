using System.Collections.Generic;

namespace MIS.Application.DTOs.Group
{
    public class GroupFullInfoDTO : GroupInfoDTO
    {
        public int NumOfStudents { get; set; }
        public IEnumerable<string> Teachers { get; set; }
    }
}
