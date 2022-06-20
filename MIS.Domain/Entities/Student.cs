using System.Collections.Generic;
using System;
using MIS.Shared;

namespace MIS.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<StudentGroupHistory> GroupHistory { get; set; }
        public ICollection<Income> Payments { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
    }
}
