using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

public class UpdateLeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    public UpdateLeaveAllocationDtoValidator()
    {
        Include(new CreateLeaveAllocationDtoValidator());
    }
}