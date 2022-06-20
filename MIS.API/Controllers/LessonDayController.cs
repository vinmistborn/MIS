using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.LessonDays;
using MIS.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class LessonDayController : BaseController
    {
        private readonly ILessonDayService _lessonDayService;

        public LessonDayController(ILessonDayService lessonDayService)
        {
            _lessonDayService = lessonDayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDayInfoDTO>>> GetLessonDays()
        {
            return Ok(await _lessonDayService.GetAllEntitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDayInfoDTO>> GetLessonDay(int id)
        {
            return Ok(await _lessonDayService.GetEntityInfoAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<LessonDayInfoDTO>> PostLessonDay([FromBody] LessonDayDTO lessonDay)
        {
            return Ok(await _lessonDayService.AddEntityAsync(lessonDay));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LessonDayInfoDTO>> PutLessonDay(int id, [FromBody] LessonDayDTO lessonDay)
        {
            return Ok(await _lessonDayService.UpdateEntityAsync(id, lessonDay));
        }
    }
}
