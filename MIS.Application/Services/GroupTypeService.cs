using AutoMapper;
using MIS.Application.DTOs.GroupType;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class GroupTypeService : GenericService<GroupType, GroupTypeDTO, GroupTypeDTO>, IGroupTypeService
    {
        public GroupTypeService(IRepository<GroupType> groupTypeRepo,
                                IMapper mapper): base(groupTypeRepo, mapper)
        {

        }
    }
}
