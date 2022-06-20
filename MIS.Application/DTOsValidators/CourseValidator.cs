using FluentValidation;
using MIS.Application.DTOs.Course;

namespace MIS.Application.DTOsValidators
{
    public class CourseValidator : AbstractValidator<CourseDTO>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Name)
                    .NotNull().Length(1, 30).WithMessage("Please, enter the course name");
            RuleFor(x => x.CourseLevel)
                    .NotNull().Length(1, 20).WithMessage("Please, enter the course level");
            RuleFor(x => x.CourseDuration)
                    .NotNull().Length(1, 10).WithMessage("Please, enter the course level");
            RuleFor(x => x.Fee)
                    .NotEmpty().WithMessage("Please, enter the Fee of course")
                    .GreaterThan(0).WithMessage("Please, enter valid fee");                    
        }
    }
}
