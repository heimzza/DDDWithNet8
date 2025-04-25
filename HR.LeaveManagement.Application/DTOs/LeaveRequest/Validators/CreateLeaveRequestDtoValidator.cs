using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    public CreateLeaveRequestDtoValidator(ILeaveRequestRepository repository)
    {
        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate)
            .WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}");
        
        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}");
        
        RuleFor(x => x.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await repository.ExistsAsync(id);
                return !leaveTypeExists;
            })
            .WithMessage("{PropertyName} does exist.");
    }
}