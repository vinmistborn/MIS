using FluentValidation;
using MIS.Application.DTOs.Student;
using MIS.Application.Helpers;

namespace MIS.Application.DTOsValidators
{
    public class StudentValidator : AbstractValidator<StudentDTO>
    {
        public StudentValidator()
        {
            RuleFor(p => p.FirstName)
                    .NotNull()
                    .NotEmpty().WithMessage("Please, enter the student's first name ");
            RuleFor(p => p.LastName)
                    .NotNull()
                    .NotEmpty().WithMessage("Please, enter the student's last name");
            RuleFor(p => p.DoB)
                    .NotNull()
                    .NotEmpty().WithMessage("Please, enter the student's date of birth");
            RuleFor(p => p.PhoneNumber)
                    .Cascade(CascadeMode.Stop)
                    .NotNull().WithMessage("Please, enter student's phone number")
                    .Must(PhoneNumberValidator.IsPhoneValid).WithMessage("Please, enter a valid phone number");              
        }
    }
}
