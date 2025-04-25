using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationRequest, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new Exception(validationResult.Errors.ToString());
        }
        
        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
        
        await _leaveAllocationRepository.AddAsync(leaveAllocation);
        
        return leaveAllocation.Id;
    }
}