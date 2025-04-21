using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class UpdateLeaveAllocationRequest : IRequest<Unit>
{
    public LeaveAllocationDto LeaveAllocationDto { get; set; }
}