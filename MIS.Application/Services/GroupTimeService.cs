using AutoMapper;
using MIS.Application.DTOs.GroupTime;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class GroupTimeService : GenericService<GroupTime, GroupTimeDTO, GroupTimeDTO>, IGroupTimeService
    {
        public GroupTimeService(IRepository<GroupTime> repo,
                                IMapper mapper) : base(repo, mapper)
        {
          
        }
    }
}
