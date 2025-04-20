using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class CreateLeaveAllocationRequest : IRequest<int>
{
    public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
}