using AutoMapper;
using MIS.Application.DTOs.Course;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class CourseService : GenericService<Course, CourseDTO, CourseDTO>, ICourseService
    {
        public CourseService(IRepository<Course> repo,
                             IMapper mapper) :  base(repo, mapper)
        {
          
        }
    }
}
