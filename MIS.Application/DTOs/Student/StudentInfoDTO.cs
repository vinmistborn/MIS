using System.Collections.Generic;

namespace MIS.Application.DTOs.Student
{
   public class StudentInfoDTO 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DoB { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<string> Groups { get; set; }
    }
}
