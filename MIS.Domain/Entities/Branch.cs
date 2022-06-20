using MIS.Domain.Entities.CashFlow;
using MIS.Domain.Entities.Identity;
using MIS.Shared;
using System.Collections.Generic;

namespace MIS.Domain.Entities
{
    public class Branch : BaseEntity
    {       
        public string District { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
        public ICollection<User> Employees { get; set; }
        public ICollection<Room> Rooms { get; set; }        
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expenses> Expenses { get; set; }
    }
}
