using Ardalis.Specification;
using MIS.Application.DTOs.Group;
using MIS.Domain.Entities;

namespace MIS.Application.Specifications
{
   public class GroupLessonDaySpec : Specification<LessonDay>, ISingleResultSpecification
    {
        public GroupLessonDaySpec(AddGroupDTO groupDTO)
        {
            
        }
    }
}
