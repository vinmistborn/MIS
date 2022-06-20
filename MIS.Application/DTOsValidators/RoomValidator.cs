using FluentValidation;
using MIS.Application.DTOs.Room;

namespace MIS.Application.DTOsValidators
{
    public class RoomValidator : AbstractValidator<RoomDTO>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Code)
                    .NotNull().Length(1, 6).WithMessage("Please, enter the room code");
            RuleFor(x => x.Capacity)                    
                    .NotNull()
                    .NotEmpty()
                    .GreaterThan(0).WithMessage("Please, enter the capacity of the room");
            RuleFor(x => x.BranchId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Please, enter the branch");
        }        
    }
}
