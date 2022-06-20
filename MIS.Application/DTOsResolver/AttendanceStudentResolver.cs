using AutoMapper;
using MIS.Application.DTOs.Attendance;
using MIS.Domain.Entities;

namespace MIS.Application.DTOsResolver
{
    public class AttendanceStudentResolver : IValueResolver<Attendance, AttendanceInfoDTO, string>
    {
        public string Resolve(Attendance source, AttendanceInfoDTO destination, string destMember, ResolutionContext context)
        {
            string name = "";
            if(source.Student != null)
            {
                name = $"{source.Student.FirstName} {source.Student.LastName}";
            }
            return name;
        }
    }
}
