using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;

namespace HR.LeaveManagement.Application.DTOs.LeaveType;

public class UpdateLeaveTypeDto : CreateLeaveTypeDto
{
    public int Id { get; set; }
}