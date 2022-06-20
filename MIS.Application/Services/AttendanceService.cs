using AutoMapper;
using MIS.Application.DTOs.Attendance;
using MIS.Application.Interfaces.Repositories;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.AttendanceSpec;
using MIS.Application.Specifications.GroupSpec;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using MIS.Domain.Exceptions.Group;
using MIS.Shared.Exceptions;
using MIS.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class AttendanceService : GenericService<Attendance, AttendanceDTO, AttendanceInfoDTO>, IAttendanceService
    {
        private readonly IGroupRepository _groupRepo;
        
        public AttendanceService(IRepository<Attendance> repo,
                                IMapper mapper,
                                IGroupRepository groupRepo) :  base(repo, mapper)
        {
            _groupRepo = groupRepo;
        }

        public async Task<IEnumerable<AttendanceInfoDTO>> AddAttendanceListAsync(AddAttendanceDTO attendanceDTO)
        {
            var group = await _groupRepo.GetBySpecAsync(new GroupWithStudentsSpec(attendanceDTO.GroupId));

            if(group.StudentGroupHistory.Count == 0)
            {
                throw new GroupEmptyException(group.Code);
            }

            //if(group.Students.Count == 0)
            //{
            //    throw new GroupEmptyException(group.Code);
            //}

            var attendances = new List<Attendance>();
            var students = group.StudentGroupHistory;
            foreach (var student in students)
            {                
                attendances.Add(new Attendance(attendanceDTO.DateTime, attendanceDTO.SessionNumber, student.StudentId, group.Id));
            }

            var attendanceList = await _repo.AddRangeAsync(attendances);
            return _mapper.Map<IEnumerable<AttendanceInfoDTO>>(attendanceList);
        }

        public async Task<IEnumerable<AttendanceInfoDTO>> GetGroupAttendance(int groupId)
        {
            var group = await _groupRepo.GetByIdAsync(groupId);
            var groupAttendance = await _repo.ListAsync(new AttendanceFilterGroupSpec(group.Id));                        
            return _mapper.Map<IEnumerable<AttendanceInfoDTO>>(groupAttendance);
        }

        public async Task<IEnumerable<AttendanceInfoDTO>> GetStudentAttendance(int studentId)
        {
            var studentAttendance = await _repo.ListAsync(new AttendanceFilterStudentSpec(studentId));
            return _mapper.Map<IEnumerable<AttendanceInfoDTO>>(studentAttendance);
        }

        public async Task<AttendanceInfoDTO> UpdateStudentAttendanceAsync(int id, UpdateAttendanceDTO attendanceDTO)
        {
            var attendance = await _repo.GetBySpecAsync(new AttendanceWithIncludesSpec(attendanceDTO.Id));

            if(attendance == null)
            {
                throw new EntityNotFoundException();
            }

            if (id != attendanceDTO.Id)
            {
                throw new ArgumentException($"Id - {id} does not match with attendance id - {attendanceDTO.Id}");
            }

            attendance.AttendanceStatus = attendanceDTO.AttendanceStatus;
            await _repo.SaveChangesAsync();
            return await GetEntityInfoSpecAsync(new AttendanceWithIncludesSpec(attendance.Id));
        }
    }
}
