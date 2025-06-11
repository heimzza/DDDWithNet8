using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<LeaveType> GetLeaveTypeWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveType>> GetLeaveTypesWithDetails()
    {
        throw new NotImplementedException();
    }
}