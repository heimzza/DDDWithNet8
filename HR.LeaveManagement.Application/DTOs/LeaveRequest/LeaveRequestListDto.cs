using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public class LeaveRequestListDto : BaseDto
{
    public bool? IsApproved { get; set; }
    public DateTime RequestDate { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
}