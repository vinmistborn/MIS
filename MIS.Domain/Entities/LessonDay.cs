using MIS.Shared;
using System;

namespace MIS.Domain.Entities
{
    public class LessonDay : BaseEntity
    {       
        public DayOfWeek DayOfWeek { get; set; }       
    }
}
