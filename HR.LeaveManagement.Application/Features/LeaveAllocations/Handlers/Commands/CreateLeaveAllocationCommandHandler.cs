using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationRequest, BaseCommandResponse>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    
    public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Invalid leave allocation data.";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            return response;
        }
        
        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
        
        await _leaveAllocationRepository.AddAsync(leaveAllocation);
        
        response.Success = true;
        response.Message = "Leave Allocation Created Successfully";
        response.Id = leaveAllocation.Id;
        
        return response;
    }
}