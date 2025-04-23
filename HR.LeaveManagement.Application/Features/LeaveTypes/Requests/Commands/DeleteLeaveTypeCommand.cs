using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;

public class DeleteLeaveTypeCommand : IRequest, IRequest<Unit>
{
    public int Id { get; set; }
}