using System;

namespace MIS.Application.DTOs.Student
{
   public class StudentDTO 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }        
    }
}
