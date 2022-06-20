using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MIS.Application.DTOs.Group;
using MIS.Application.DTOs.Teacher;
using MIS.Domain.Entities;
using MIS.Domain.Exceptions.Teacher;
using MIS.Application.Interfaces.Services;
using MIS.Application.Interfaces.Repositories;
using MIS.Application.Specifications;
using MIS.Application.Specifications.GroupSpec;
using MIS.Shared.Exceptions;
using MIS.Shared.Interfaces;
using MIS.Shared.Interfaces.Repositories;
using System.Threading.Tasks;
using MIS.Domain.Enums;

namespace MIS.Application.Services
{
    public class TeacherService : GenericUserService<Teacher, TeacherInfoDTO>, ITeacherService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IRepository<GroupTeacher> _groupTeacherRepo;

        public TeacherService(UserManager<Teacher> userManager,
                              IGenericUserRepository<Teacher> teacherRepo,
                              IMapper mapper,
                              IGroupRepository groupRepo,
                              IRepository<GroupTeacher> groupTeacherRepo)
                              : base(userManager, teacherRepo, mapper)
        {
            _groupRepo = groupRepo;
            _groupTeacherRepo = groupTeacherRepo;
        }

        public async Task<TeacherInfoDTO> AddGroupToTeacherAsync(int groupId, int teacherId)
        {
            var group = await _groupRepo.GetBySpecAsync(new GroupWithIncludesSpec(groupId));
            
            if (group == null)
            {
                throw new EntityNotFoundException(groupId);
            }
            var teacher = await _userRepo.GetBySpecAsync(new TeacherWithIncludesSpec(teacherId));
            if (teacher == null)
            {
                throw new EntityNotFoundException(teacherId);
            }
            if (teacher.Groups.Contains(group))
            {
                var groupDTO = _mapper.Map<GroupFullInfoDTO>(group);
                throw new GroupAssignedException(groupDTO.Code, teacher.FirstName);
            }
            
            teacher.Groups.Add(group);
            await _groupTeacherRepo.AddAsync(new GroupTeacher(group, teacher));
            return _mapper.Map<TeacherInfoDTO>(teacher);
        }

        public async Task<TeacherInfoDTO> RemoveGroupFromTeacherAsync(int groupId, int teacherId)
        {
            var group = await _groupRepo.GetBySpecAsync(new GroupWithIncludesSpec(groupId));
            if (group == null)
            {
                throw new EntityNotFoundException(groupId);
            }
            var teacher = await _userRepo.GetBySpecAsync(new TeacherWithIncludesSpec(teacherId));
            teacher.Groups.Remove(group);
            await _groupTeacherRepo.SaveChangesAsync();
            return _mapper.Map<TeacherInfoDTO>(teacher);
        }

        public async Task RemoveGroupsFromTeacherAsync(int teacherId)
        {
            var teacher = await _userRepo.GetBySpecAsync(new TeacherWithIncludesSpec(teacherId));
            teacher.Groups.Clear();
            await _groupTeacherRepo.SaveChangesAsync();
        }

        public override async Task<TeacherInfoDTO> UpdateUserStatusAsync(int userId, EmployeeStatus employeeStatus)
        {
            var teacher = await base.UpdateUserStatusAsync(userId, employeeStatus);
            if(employeeStatus == EmployeeStatus.Quit || employeeStatus == EmployeeStatus.OnLeave)
            {
                await RemoveGroupsFromTeacherAsync(userId);
            }           
            return teacher;
        }
    }
}
