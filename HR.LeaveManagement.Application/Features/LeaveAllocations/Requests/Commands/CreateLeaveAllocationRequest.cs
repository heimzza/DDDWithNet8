using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class CreateLeaveAllocationRequest : IRequest<BaseCommandResponse>
{
    public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
}