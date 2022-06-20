using MIS.Application.DTOs.LessonDays;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;

namespace MIS.Application.Interfaces.Services
{
    public interface ILessonDayService : IGenericService<LessonDay, LessonDayDTO, LessonDayInfoDTO>
    {

    }
}
