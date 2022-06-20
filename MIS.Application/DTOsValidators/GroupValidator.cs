using FluentValidation;
using MIS.Application.DTOs.Group;

namespace MIS.Application.DTOsValidators
{
    public class GroupValidator : AbstractValidator<AddGroupDTO>
    {
        public GroupValidator()
        {
            RuleFor(p => p.GroupTypeId)
                    .NotNull().WithMessage("Please, enter group type");
            RuleFor(p => p.Capacity)
                    .NotNull().WithMessage("Please, enter capacity");
            RuleFor(p => p.CourseId)
                    .NotNull().WithMessage("Please enter course"); 
        }
    }
}
