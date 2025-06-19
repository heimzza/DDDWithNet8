using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
{
    public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository repository)
    {
        Include(new CreateLeaveRequestDtoValidator(repository));
        
        RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required.");
    }
}