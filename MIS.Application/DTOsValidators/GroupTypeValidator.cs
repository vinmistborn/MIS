using FluentValidation;
using MIS.Application.DTOs.GroupType;

namespace MIS.Application.DTOsValidators
{
   public class GroupTypeValidator :AbstractValidator<GroupTypeDTO>
    {
        public GroupTypeValidator()
        {
            RuleFor(p => p.Type)
                    .NotNull().WithMessage("Type field required");
            RuleFor(p => p.FeeIncreaseBy)
                    .GreaterThan(0).WithMessage("Please, enter a valid value");
        }
    }
}
