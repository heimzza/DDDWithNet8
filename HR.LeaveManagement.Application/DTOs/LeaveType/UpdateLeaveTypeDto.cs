using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;

namespace HR.LeaveManagement.Application.DTOs.LeaveType;

public class UpdateLeaveTypeDto : ILeaveTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}