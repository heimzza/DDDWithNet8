using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

public class UpdateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeDto>
{
    public UpdateLeaveTypeDtoValidator()
    {
        Include(new CreateLeaveTypeDtoValidator());
        
        RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required.");
    }
}