using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

public class CreateLeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        
        RuleFor(x => x.DefaultDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
    }
}