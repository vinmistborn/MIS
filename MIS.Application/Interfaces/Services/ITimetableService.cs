using MIS.Application.DTOs.Timetable;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface ITimetableService : IGenericService<Timetable, UpdateTimetableDTO, TimetableInfoDTO>
    {
        public Task<IEnumerable<TimetableInfoDTO>> GetTimetableSlots(IEnumerable<Timetable> timetables);
        public Task<IEnumerable<TimetableInfoDTO>> AddTimetableSlotsAsync(AddTimetableDTO timetableDTO);
        public Task<IEnumerable<TimetableInfoDTO>> UpdateGroupTimetableAsync(UpdateGroupTimetableDTO timetableDTO);
        public Task<IEnumerable<TimetableFullInfoDTO>> GetGroupTimetable(int groupId);
        public Task<IEnumerable<TimetableFullInfoDTO>> GetTeacherTimetable(int teacherId);
        public Task<IEnumerable<TimetableFullInfoDTO>> GetCourseTimetable(int courseId);
    }
}
