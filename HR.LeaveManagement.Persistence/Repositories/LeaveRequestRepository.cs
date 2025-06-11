using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _dbContext.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
        
        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _dbContext.LeaveRequests
            .Include(q => q.LeaveType)
            .ToListAsync();
        
        return leaveRequests;
    }

    public async Task ChangeApprovalStatusAsync(LeaveRequest leaveRequest, bool? isApproved)
    {
        leaveRequest.IsApproved = isApproved;
        
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        
        await _dbContext.SaveChangesAsync();
    }
}