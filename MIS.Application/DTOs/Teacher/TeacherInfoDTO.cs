using MIS.Application.DTOs.User;
using System.Collections.Generic;

namespace MIS.Application.DTOs.Teacher
{
    public class TeacherInfoDTO : UserInfoDTO
    {
        public IEnumerable<string> Groups { get; set; }
    }
}
