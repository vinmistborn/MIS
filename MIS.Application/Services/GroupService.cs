using AutoMapper;
using MIS.Application.DTOs.Group;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using MIS.Application.Interfaces.Repositories;
using MIS.Application.Specifications.GroupSpec;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MIS.Shared.Exceptions;
using Hangfire;
using MIS.Application.Specifications.StudentGroupHistorySpec;

namespace MIS.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly ICourseService _courseService;
        private readonly IGroupTypeService _groupTypeService;
        private readonly IStudentGroupHistoryRepository _historyRepo;
        private readonly IMapper _mapper;        

        public GroupService(IGroupRepository groupRepo,
                            ICourseService courseService,
                            IGroupTypeService groupTypeService,
                            IStudentGroupHistoryRepository historyRepo,
                            IMapper mapper)
        {
            _groupRepo = groupRepo;
            _courseService = courseService;
            _groupTypeService = groupTypeService;
            _historyRepo = historyRepo;
            _mapper = mapper;
        }

        public async Task<GroupInfoDTO> AddGroupAsync(AddGroupDTO groupDTO)
        {
            if(groupDTO == null)
            {
                throw new ArgumentNullException("Please, enter a group");
            }
            var group = _mapper.Map<Group>(groupDTO);
            group.Fee = await CalculateGroupFee(groupDTO.CourseId, groupDTO.GroupTypeId);
            group.IsActive = true;
            var newGroup = await _groupRepo.AddAsync(group);
            return _mapper.Map<GroupInfoDTO>(newGroup);
        }

        public async Task<decimal> CalculateGroupFee(int courseId, int groupTypeId)
        {
            var course = await _courseService.GetEntityInfoAsync(courseId);
            var groupType = await _groupTypeService.GetEntityInfoAsync(groupTypeId);
            return course.Fee * groupType.FeeIncreaseBy;
        }

        public async Task<GroupInfoDTO> ArchiveGroupAsync(int id)
        {
            var group = await _groupRepo.GetByIdAsync(id);

            if (group == null)
            {
                throw new EntityNotFoundException(id);
            }

            group.IsActive = false;
            await _groupRepo.SaveChangesAsync();

            BackgroundJob.Schedule<IStudentGroupHistoryService>(x => x.UpdateArchivedGroupHistoryAsync(group.Id), TimeSpan.FromDays(1));

            return _mapper.Map<GroupInfoDTO>(group);
        }

        public async Task ArchiveGroupsAsync()
        {
            await _groupRepo.DeleteRangeAsync(await _groupRepo.GetFinishedGroups());
        }

        public async Task<IEnumerable<GroupFullInfoDTO>> GetAllGroupsAsync()
        {
            var groups = await _groupRepo.ListAsync(new GroupWithIncludesSpec());
            foreach (var group in groups)
            {
                await UpdateStudentCount(group);
            }  
            return _mapper.Map<IEnumerable<GroupFullInfoDTO>>(groups);
        }

        public async Task<GroupFullInfoDTO> GetGroupInfoAsync(int id)
        {
            var group = await _groupRepo.GetBySpecAsync(new GroupWithIncludesSpec(id));
            var groupWithStudentCount = await UpdateStudentCount(group);
            return _mapper.Map<GroupFullInfoDTO>(groupWithStudentCount);
        }

        private async Task<Group> UpdateStudentCount(Group group)
        {
            var groupHistory = await _historyRepo.ListAsync(new GroupHistorySpec(group.Id));
            group.NumOfStudents = groupHistory.Count;
            await _groupRepo.SaveChangesAsync();
            return group;
        }

        public async Task<IEnumerable<GroupFullInfoDTO>> GetTeacherGroups(int teacherId)
        {
            return _mapper.Map<IEnumerable<GroupFullInfoDTO>>(await _groupRepo.GetTeacherGroups(teacherId));
        }

        public async Task<GroupFullInfoDTO> UpdateGroupAsync(int id, UpdateGroupDTO groupDTO)
        {
            if(groupDTO == null)
            {
                throw new ArgumentException();
            }
            if(id != groupDTO.Id)
            {
                throw new ArgumentException($"Id - {id} does not match with group id - {groupDTO.Id}");
            }
            var group = await _groupRepo.GetBySpecAsync(new GroupWithIncludesSpec(id));
            var updatedGroup = _mapper.Map(groupDTO, group);
            
            await _groupRepo.UpdateAsync(updatedGroup);
            return await GetGroupInfoAsync(updatedGroup.Id);
        }

        public async Task<GroupInfoDTO> UpdateGroupCourseAsync(int id, GroupCourseUpdate courseId)
        {
            var group = await _groupRepo.GetBySpecAsync(new GroupWithStudentsSpec(id));
            
            if (group == null)
            {
                throw new EntityNotFoundException(id);
            }

            var course = _courseService.GetEntityInfoAsync(courseId.CourseId);

            if (course == null)
            {
                throw new EntityNotFoundException(id);
            }

            BackgroundJob.Schedule<IStudentGroupHistoryService>(x => x.UpdateGroupCourseHistory(group.Id, course.Id),
                                            TimeSpan.FromDays(1));

            group.CourseId = course.Id;
            group.Fee = await CalculateGroupFee(course.Id, group.GroupTypeId);
            await _groupRepo.SaveChangesAsync();

            foreach (var student in group.Students)
            {
                await _historyRepo.AddHistory(student.Id, group.Id, course.Id);
            }

            return _mapper.Map<GroupInfoDTO>(group);
        }

        public async Task<GroupInfoDTO> GetGroupForUpdate(int id)
        {
            return _mapper.Map<GroupInfoDTO>(await _groupRepo.GetByIdAsync(id));
        }

        public async Task<AddGroupDTO> GetGroupUpdate(int id)
        {
            return _mapper.Map<AddGroupDTO>(await _groupRepo.GetByIdAsync(id));
        }
    }
}
