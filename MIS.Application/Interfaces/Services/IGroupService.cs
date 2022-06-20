using MIS.Application.DTOs.Group;
using MIS.Shared.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupFullInfoDTO>> GetAllGroupsAsync();
        Task<GroupFullInfoDTO> GetGroupInfoAsync(int id);
        Task<IEnumerable<GroupFullInfoDTO>> GetTeacherGroups(int teacherId);
        Task<GroupInfoDTO> AddGroupAsync(AddGroupDTO groupDTO);
        Task<GroupInfoDTO> ArchiveGroupAsync(int id);
        Task<GroupFullInfoDTO> UpdateGroupAsync(int id, UpdateGroupDTO groupDTO);
        Task<GroupInfoDTO> UpdateGroupCourseAsync(int id, GroupCourseUpdate courseId);
        Task ArchiveGroupsAsync();
        Task<decimal> CalculateGroupFee(int courseId, int groupTypeId);
        Task<GroupInfoDTO> GetGroupForUpdate(int id);
        Task<AddGroupDTO> GetGroupUpdate(int id);
    }
}
