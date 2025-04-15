using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest : BaseDomainEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? ActionDate { get; set; }
    public bool? IsApproved { get; set; }
    public bool IsCancelled { get; set; }
}