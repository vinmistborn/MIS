using FluentValidation;
using MIS.Application.DTOs.GroupTime;
using System.Text.RegularExpressions;

namespace MIS.Application.DTOsValidators
{
    public class GroupTimeValidator : AbstractValidator<GroupTimeDTO>
    {
        public GroupTimeValidator()
        {
            RuleFor(x => x.Time)
                   .NotNull()
                   .NotEmpty().WithMessage("Please, enter time")
                   .Must(IsTimeValid).WithMessage("Please, enter valid time");
        }

        private bool IsTimeValid(string time)
        {
            return Regex.IsMatch(time, "[0-9]{2}:[0-9]{2}-[0-9]{2}:[0-9]{2}");
        }
    }
}
