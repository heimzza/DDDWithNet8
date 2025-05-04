using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

public class CreateLeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        
        RuleFor(x => x.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        
        RuleFor(x => x.Period)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

        RuleFor(x => x.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var isLeaveTypeExists = await _leaveTypeRepository.ExistsAsync(id);
                return !isLeaveTypeExists;
            })
            .WithMessage("{PropertyName} must be greater than zero.");
    }
}