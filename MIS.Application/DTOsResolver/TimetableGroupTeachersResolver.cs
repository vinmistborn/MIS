using AutoMapper;
using MIS.Application.DTOs.Timetable;
using MIS.Application.Interfaces.Services;
using MIS.Domain.Entities;
using System.Collections.Generic;

namespace MIS.Application.DTOsResolver
{
    public class TimetableGroupTeachersResolver : IValueResolver<Timetable, TimetableFullInfoDTO, string>
    {
        public string Resolve(Timetable source, TimetableFullInfoDTO destination, string destMember, ResolutionContext context)
        {
            string teacherName = "";
            if (source.Group != null)
            {
                var teacherNames = new List<string>();
                var teachers = source.Group.Teachers;
                foreach (var teacher in teachers)
                {
                    teacherNames.Add($"{teacher.FirstName} {teacher.LastName}");
                }
                teacherName = string.Join(",", teacherNames);
            }
            return teacherName;
        }
    }
}
