using HR.LeaveManagement.Application.DTOs.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public class UpdateLeaveRequestDto : CreateLeaveRequestDto
{
    public int Id { get; set; }
    public bool IsCancelled { get; set; }
}