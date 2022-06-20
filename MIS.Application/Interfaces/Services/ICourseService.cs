using MIS.Application.DTOs.Course;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;

namespace MIS.Application.Interfaces.Services
{
    public interface ICourseService : IGenericService<Course, CourseDTO, CourseDTO>
    {
    }
}
