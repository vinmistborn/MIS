using FluentValidation;
using MIS.Application.DTOs.Branch;
using MIS.Application.Helpers;

namespace MIS.Application.DTOsValidators
{
    public class BranchValidator : AbstractValidator<BranchDTO>
    {
        public BranchValidator()
        {
            RuleFor(x => x.Address)
                    .NotNull().Length(5, 30).WithMessage("Please, enter the address");
            RuleFor(x => x.District)
                    .NotNull().Length(5, 30).WithMessage("Please, enter the district");
            RuleFor(x => x.PhoneNumber)
                    .Cascade(CascadeMode.Stop)
                    .NotNull().WithMessage("Please, enter the phone number")
                    .Must(PhoneNumberValidator.IsPhoneValid).WithMessage("Please, enter a valid phone number");           
        }        
    }
}
