using MIS.Shared;
using System.Collections.Generic;

namespace MIS.Domain.Entities
{
    public class GroupType : BaseEntity
    {
        public string Type { get; set; }
        public decimal IncreaseFeeBy { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
