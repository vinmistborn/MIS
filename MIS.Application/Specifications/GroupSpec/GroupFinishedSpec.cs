using Ardalis.Specification;
using MIS.Domain.Entities;
using System.Linq;

namespace MIS.Application.Specifications.GroupSpec
{
    public class GroupFinishedSpec : Specification<Group>
    {
        public GroupFinishedSpec()
        {
            Query
                .Where(p => p.IsActive == false);
        }
    }
}
