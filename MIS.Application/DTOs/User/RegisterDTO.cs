using System;

namespace MIS.Application.DTOs.User
{
   public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public int? BranchId { get; set; }
        public string Email { get; set; }        
        public string Password { get; set; }        
    }
}
