using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;

public class DeleteLeaveRequestCommand : IRequest, IRequest<Unit>
{
    public int Id { get; set; }
}