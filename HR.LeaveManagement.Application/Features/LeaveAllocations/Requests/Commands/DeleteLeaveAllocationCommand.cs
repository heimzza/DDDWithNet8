using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class DeleteLeaveAllocationCommand : IRequest, IRequest<Unit>
{
    public int Id { get; set; }
}