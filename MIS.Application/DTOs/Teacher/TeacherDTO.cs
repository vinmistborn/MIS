using MIS.Domain.Enums;
using System;

namespace MIS.Application.DTOs.Teacher
{
   public class TeacherDTO 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public EmployeeStatus Status { get; set; }
        public int BranchId { get; set; }
    }
}
