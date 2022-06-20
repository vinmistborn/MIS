using MIS.Application.Interfaces.Repositories;
using MIS.Application.Interfaces.Services;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class GroupCodeService : IGroupCodeService
    {
        private readonly ITimetableRepository _timetableRepo;

        public GroupCodeService(ITimetableRepository timetableRepo)
        {
            _timetableRepo = timetableRepo;
        }

        public async Task<string> GetGroupCode(Group group)
        {
            var teacherInitials = GetTeachersNameInitials(group.Teachers);
            var lessonDays = await GetLessonDaysChars(group.Timetable);
            var groupTime = await GetGroupTime(group.Timetable);
            return $"{teacherInitials}-{lessonDays}-{groupTime}";
        }

        private string GetTeachersNameInitials(ICollection<Teacher> teachers)
        {
            return string.Join("-", teachers
                         .Select(x => $"{GetNameInitials(x.FirstName)}{GetNameInitials(x.LastName)}"));
        }

        private string GetNameInitials(string name)
        {
            return name.Substring(0, 2)
                             .ToUpper()
                                 .Contains("SH") ? name.Substring(0, 2) : name.Substring(0, 1);
        }

        private async Task<string> GetGroupTime(ICollection<Timetable> timetables)
        {
            var slots = await _timetableRepo.GetTimetablesByIdsAsync(timetables);
            var groupTime = slots.First().GroupTime.Time;
            return groupTime.Substring(0, 2);
        }

        private async Task<string> GetLessonDaysChars(ICollection<Timetable> timetables)
        {
            var slots = await _timetableRepo.GetTimetablesByIdsAsync(timetables);
            return string.Join("/", slots.Select(x => x.LessonDay.DayOfWeek.ToString().Substring(0, 3)));
        }
    }
}
