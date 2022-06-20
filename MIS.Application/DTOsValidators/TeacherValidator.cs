using FluentValidation;
using MIS.Application.DTOs.Teacher;

namespace MIS.Application.DTOsValidators
{
    public class TeacherValidator : AbstractValidator<TeacherDTO>
    {
        public TeacherValidator()
        {
            RuleFor(p => p.Status)
                    .NotNull()
                    .WithMessage("Please, enter the teacher status");
            RuleFor(p => p.BranchId)
                    .NotNull()
                    .WithMessage("Please, enter the branch");
        }
    }
}
