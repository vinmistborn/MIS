using AutoMapper;
using MIS.Application.DTOs.Timetable;
using MIS.Application.Interfaces.Services;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.DTOsResolver
{
    public class TimetableGroupCourseResolver : IValueResolver<Timetable, TimetableFullInfoDTO, string>
    {
        public string Resolve(Timetable source, TimetableFullInfoDTO destination, string destMember, ResolutionContext context)
        {
            string course = "";
            if (source.Group != null)
            {
                course = source.Group.Course.Name;
            }
            return course;
        }
    }
}
