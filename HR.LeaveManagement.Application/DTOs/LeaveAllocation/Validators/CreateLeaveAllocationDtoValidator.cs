using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
{
    public CreateLeaveAllocationDtoValidator()
    {
        RuleFor(x => x.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        
        RuleFor(x => x.Period)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
    }
}