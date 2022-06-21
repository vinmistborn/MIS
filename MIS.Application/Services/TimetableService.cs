using AutoMapper;
using MIS.Application.DTOs.Timetable;
using MIS.Application.Interfaces.Repositories;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.GroupSpec;
using MIS.Application.Specifications.TimetableSpec;
using MIS.Domain.Entities;
using MIS.Domain.Exceptions.Room;
using MIS.Domain.Exceptions.Timetable;
using MIS.Shared.Exceptions;
using MIS.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class TimetableService :GenericService<Timetable, UpdateTimetableDTO, TimetableInfoDTO>, ITimetableService
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IGroupRepository _groupRepository;
        private readonly ITimetableRepository _timetableRepo;        

        public TimetableService(ITimetableRepository timetableRepo,
                                IRepository<Room> roomRepo,
                                IGroupRepository groupRepository,                               
                                IMapper mapper) : base(timetableRepo, mapper)
        {
            _timetableRepo = timetableRepo;
            _roomRepo = roomRepo;
            _groupRepository = groupRepository;           
        }

        public async Task<IEnumerable<TimetableInfoDTO>> AddTimetableSlotsAsync(AddTimetableDTO timetableDTO)
        {
            if (timetableDTO is null)
            {
                throw new ArgumentNullException();
            }

            var timetableList = new List<Timetable>();
            var lessonDays = timetableDTO.LessonDayIds;
           
            for (int i = 0; i < lessonDays.Length; i++)
            {
                var slot = new Timetable(lessonDays[i], timetableDTO.GroupTimeId, timetableDTO.RoomId);
                await CheckForExistingTimetable(slot);
                timetableList.Add(slot);
            }
            
            var slots = await _timetableRepo.AddRangeAsync(timetableList);
            return await GetTimetableSlots(slots);
        }

        public override async Task<TimetableInfoDTO> UpdateEntityAsync(int id, UpdateTimetableDTO timetableDTO)
        {
            var timetable = await _repo.GetBySpecAsync(new TimetableSpec(id));
            if (timetable is null)
            {
                throw new EntityNotFoundException("timetable",id);
            }

            if (id != timetableDTO.Id)
            {
                throw new ArgumentException($"Id - {id} does not match with timetable id - {timetableDTO.Id}");
            }

            var updatedTimetable = _mapper.Map(timetableDTO, timetable);
            await CheckForExistingTimetable(timetable);

            await _timetableRepo.UpdateAsync(updatedTimetable);
            return await GetEntityInfoSpecAsync(new TimetableSpec(updatedTimetable.Id));
        }

        public async Task<IEnumerable<TimetableInfoDTO>> UpdateGroupTimetableAsync(UpdateGroupTimetableDTO timetableDTO)
        {
            if(timetableDTO is null)
            {
                throw new ArgumentNullException();
            }

            var timetableList = new List<Timetable>();
            var group = await _groupRepository.GetBySpecAsync(new GroupWithIncludesSpec(timetableDTO.GroupId));
            foreach (var id in timetableDTO.TimetableIds)
            {
                var timetable = await _repo.GetBySpecAsync(new TimetableSpec(id));
                if(timetable.Group != null)
                {
                    throw new RoomBookedException();
                }

                await CheckBookedSlots(timetable, group);
                await CompareGroupRoomCapacityAsync(group, timetable);

                timetable.GroupId = timetableDTO.GroupId;
                timetableList.Add(timetable);
            }

            var slots = await _timetableRepo.UpdateRangeAsync(timetableList);
            return await GetTimetableSlots(slots);
        }


        private async Task CheckBookedSlots(Timetable timetable, Group group)
        {
            var bookedSlots = await _repo.ListAsync(new TimetableWithGroupSpec(timetable.LessonDayId, timetable.GroupTimeId));
            foreach (var slot in bookedSlots)
            {
                CheckGroupTeacher(slot, group);
            }
        }

        private void CheckGroupTeacher(Timetable timetable, Group group)
        {
            var teachers = timetable.Group.Teachers;
            
            foreach (var teacher in teachers)
            {
                if (group.Teachers.Contains(teacher))
                {
                    throw new TeacherBookedException($"{teacher.FirstName} {teacher.LastName}");
                }
            }
        }

        private async Task<Timetable> CheckForExistingTimetable(Timetable timetable)
        {
            var existingTimetable = await _repo.GetBySpecAsync(new TimetableSpec(timetable.LessonDayId, timetable.GroupTimeId, timetable.RoomId));
            
            if (existingTimetable != null)
            {
                throw new DuplicateTimetableSlotException(existingTimetable.Room.Code, existingTimetable.LessonDay.DayOfWeek.ToString(), existingTimetable.GroupTime.Time);
            }
            return timetable;
        }

        private async Task CompareGroupRoomCapacityAsync(Group group, Timetable timetable)
        {
            var room = await _roomRepo.GetByIdAsync(timetable.RoomId);
            if (group.Capacity > room.Capacity)
            {
                throw new RoomCapacityConflictException(group.Capacity);
            }
        }

        public async Task<IEnumerable<TimetableInfoDTO>> GetTimetableSlots(IEnumerable<Timetable> timetables)
        {
            var slots = await _timetableRepo.GetTimetablesByIdsAsync(timetables);
            return _mapper.Map<IEnumerable<TimetableInfoDTO>>(slots);
        }

        public async Task<IEnumerable<TimetableFullInfoDTO>> GetGroupTimetable(int groupId)
        {
            var groupTimetableSlots = await _timetableRepo.ListAsync(new TimetableWithGroupSpec(groupId));
            
            if(groupTimetableSlots == null)
            {
                throw new GroupNotFoundException();
            }

            return _mapper.Map<IEnumerable<TimetableFullInfoDTO>>(groupTimetableSlots);
        }

        public async Task<IEnumerable<TimetableFullInfoDTO>> GetTeacherTimetable(int teacherId)
        {
            return await GetEntityTimetable(x => x.GetTeacherGroups(teacherId));
        }

        public async Task<IEnumerable<TimetableFullInfoDTO>> GetCourseTimetable(int courseId)
        {
            return await GetEntityTimetable(x => x.GetCourseGroups(courseId));
        }

        public async Task<IEnumerable<TimetableFullInfoDTO>> GetEntityTimetable(Func<IGroupRepository, Task<IEnumerable<Group>>> groupRepo)
        {
            var timetable = new List<IEnumerable<TimetableFullInfoDTO>>();
            var groups = await groupRepo(_groupRepository);

            var groupIds = groups.Select(x => x.Id);

            foreach (var id in groupIds)
            {
                var groupTimetable = await GetGroupTimetable(id);
                timetable.Add(groupTimetable);
            }

            var entityTimetable = timetable.SelectMany(x => x);

            return entityTimetable;
        }
    }
}
