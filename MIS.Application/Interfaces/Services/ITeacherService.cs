using MIS.Application.DTOs.Teacher;
using MIS.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MIS.Application.Interfaces.Services
{
    public interface ITeacherService : IGenericUserService<Teacher, TeacherInfoDTO>
    {   
        Task<TeacherInfoDTO> AddGroupToTeacherAsync(int groupId, int teacherId);
        Task<TeacherInfoDTO> RemoveGroupFromTeacherAsync(int groupId, int teacherId);
        Task RemoveGroupsFromTeacherAsync(int teacherId);
    }
}
