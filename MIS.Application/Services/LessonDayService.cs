using AutoMapper;
using MIS.Application.DTOs.LessonDays;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class LessonDayService :GenericService<LessonDay, LessonDayDTO, LessonDayInfoDTO>, ILessonDayService
    {
        public LessonDayService(IRepository<LessonDay> repo,
                                IMapper mapper) : base(repo, mapper)
        {
            
        }
    }
}
