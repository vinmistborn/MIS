using FluentValidation;
using MIS.Application.DTOs.LessonDays;

namespace MIS.Application.DTOsValidators
{
    public class LessonDayValidator : AbstractValidator<LessonDayDTO>
    {
        public LessonDayValidator()
        {
            RuleFor(x => x.DayOfWeek)
                   .NotEmpty().WithMessage("Please, enter a day");
        }
    }
}
