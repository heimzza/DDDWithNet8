using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        Include(new CreateLeaveAllocationDtoValidator(_leaveTypeRepository));
        
        RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required.");
    }
}