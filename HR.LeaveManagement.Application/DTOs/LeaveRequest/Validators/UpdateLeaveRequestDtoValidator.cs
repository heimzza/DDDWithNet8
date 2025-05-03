using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
{
    public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository repository)
    {
        Include(new CreateLeaveRequestDtoValidator(repository));
        
        RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required.");
    }
}