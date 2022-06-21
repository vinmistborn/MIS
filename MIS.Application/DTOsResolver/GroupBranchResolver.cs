using AutoMapper;
using MIS.Application.DTOs.Group;
using MIS.Domain.Entities;


namespace MIS.Application.DTOsResolver
{
    public class GroupBranchResolver : IValueResolver<Group, GroupFullInfoDTO, string>
    {
        public string Resolve(Group source, GroupFullInfoDTO destination, string destMember, ResolutionContext context)
        {
            var branch = "";
            if(source.Branch is not null)
            {
                branch = $"{source.Branch.District} {source.Branch.Address}";
            }
            return branch;
        }
    }
}
