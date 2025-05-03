using HR.LeaveManagement.Application.DTOs.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public class UpdateLeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public int Id { get; set; }
    public bool IsCancelled { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string RequestComments { get; set; }
}