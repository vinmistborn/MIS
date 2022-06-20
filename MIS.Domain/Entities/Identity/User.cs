using Microsoft.AspNetCore.Identity;
using MIS.Domain.Enums;
using System;

namespace MIS.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; } 
        public EmployeeStatus EmployeeStatus { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
