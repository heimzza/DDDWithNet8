using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationDetails(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
}