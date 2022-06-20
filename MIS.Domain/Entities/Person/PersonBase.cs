using MIS.Shared;
using System;


namespace MIS.Domain.Entities.Person
{
    public abstract class PersonBase : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
    }
}
