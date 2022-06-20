using AutoMapper;
using MIS.Application.DTOs.Student;
using MIS.Application.DTOs.StudentGroupHistory;
using MIS.Domain.Entities;
using MIS.Domain.Exceptions.Group;
using MIS.Application.Interfaces.Services;
using MIS.Application.Interfaces.Repositories;
using MIS.Application.Specifications.StudentGroupHistorySpec;
using MIS.Application.Specifications.StudentSpec;
using MIS.Shared.Exceptions;
using MIS.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hangfire;

namespace MIS.Application.Services
{
    public class StudentService : GenericService<Student, StudentDTO, StudentInfoDTO>, IStudentService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IGroupService _groupService;
        private readonly IStudentGroupHistoryRepository _studentHistoryRepo;

        public StudentService(IRepository<Student> studentRepo,
                              IGroupService groupService,
                              IGroupRepository groupRepo,
                              IStudentGroupHistoryRepository studentHistoryRepo,                             
                              IMapper mapper) : base(studentRepo, mapper)
        {
            _groupService = groupService;
            _groupRepo = groupRepo;
            _studentHistoryRepo = studentHistoryRepo; 
        }

        public async Task<StudentInfoDTO> AddStudentAsync(StudentDTO studentDTO)
        {
            if (studentDTO == null)
            {
                throw new ArgumentNullException();
            }

            var student = _mapper.Map<Student>(studentDTO);
            student.IsActive = true;

            var newStudent = await _repo.AddAsync(student);
            return await GetEntityInfoAsync(newStudent.Id);
        }

        public async Task<StudentInfoDTO> AddGroupsToStudentAsync(int studentId, NewStudentGroups groups)
        {
            var student = await _repo.GetBySpecAsync(new StudentWithGroupSpec(studentId));
            if (student == null)
            {
                throw new EntityNotFoundException(studentId);
            }
            foreach (var groupId in groups.GroupIds)
            {
                var groupInfo = await _groupService.GetGroupInfoAsync(groupId);                
                var group = await _groupRepo.GetByIdAsync(groupId);

                if (student.Groups.Contains(group))
                {                    
                    throw new DuplicateGroupException(student.FirstName, groupInfo.Code);
                }
                if (groupInfo.Capacity == groupInfo.NumOfStudents)
                {
                    throw new GroupFullException(groupInfo.Code);
                }

                await _studentHistoryRepo.AddHistory(student.Id, group.Id, group.CourseId);
            }
            return _mapper.Map<StudentInfoDTO>(student);                       
        }

        public async Task<StudentInfoDTO> ArchiveStudentAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);

            if (student == null)
            {
                throw new EntityNotFoundException(id);
            }

            student.IsActive = false;
            await _repo.SaveChangesAsync();

            BackgroundJob.Schedule<IStudentGroupHistoryService>(x => x.UpdateArchivedStudentHistoryAsync(student.Id), TimeSpan.FromDays(1));

            return await GetEntityInfoAsync(student.Id);
        }

        public async Task<IEnumerable<StudentGroupHistoryDTO>> GetStudentGroupsListAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            var studentGroupHistory = await _studentHistoryRepo.ListAsync(new StudentGroupHistorySpec(student.Id));
            return _mapper.Map<IEnumerable<StudentGroupHistoryDTO>>(studentGroupHistory);
        }

        public async Task<StudentInfoDTO> RemoveGroupFromStudent(int studentId, RemoveGroupDTO group)
        {
            var student = await _repo.GetBySpecAsync(new StudentWithGroupSpec(studentId));
            
            if(student == null)
            {
                throw new EntityNotFoundException(studentId);
            }
            
            var studentHistory = await _studentHistoryRepo.GetBySpecAsync(new StudentGroupHistorySpec(student.Id, group.GroupId));
            
            studentHistory.LastLesson = DateTime.Today;            
            await _studentHistoryRepo.UpdateAsync(studentHistory);            
            
            return await GetEntityInfoSpecAsync(new StudentWithGroupSpec(student.Id));
        }

        public async Task<StudentInfoDTO> UpdateStudentAsync(int id, StudentDTO studentDTO)
        {
            if (id != studentDTO.Id)
            {
                throw new ArgumentException($"Id - {id} does not match with student id - {studentDTO.Id}");
            }

            var student = await _repo.GetByIdAsync(id);

            if (student == null)
            {
                throw new ArgumentNullException();
            }

            var updatedStudent = _mapper.Map(studentDTO, student);

            await _repo.UpdateAsync(updatedStudent);
            return await GetEntityInfoAsync(student.Id);
        }

        public async Task<StudentDTO> GetStudentForUpdate(int id)
        {
            return _mapper.Map<StudentDTO>(await _repo.GetByIdAsync(id)); 
        }
    }
}
