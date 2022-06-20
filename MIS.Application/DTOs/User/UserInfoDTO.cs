using System;
using System.Collections.Generic;

namespace MIS.Application.DTOs.User
{
   public class UserInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DoB { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Branch { get; set; }
        public string EmployeeStatus { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
