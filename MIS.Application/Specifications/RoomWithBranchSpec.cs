using Ardalis.Specification;
using MIS.Domain.Entities;

namespace MIS.Application.Specifications
{
    public class RoomWithBranchSpec : Specification<Room>, ISingleResultSpecification
    {
        public RoomWithBranchSpec()
        {
            Query
                .Include(p => p.Branch);
        }

        public RoomWithBranchSpec(int id) : this()
        {
            Query
                .Where(p => p.Id == id);
        }
    }
}
