using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationRequestHandler : IRequestHandler<CreateLeaveAllocationRequest, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
        
        await _leaveAllocationRepository.AddAsync(leaveAllocation);
        
        return leaveAllocation.Id;
    }
}