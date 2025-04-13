using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<LeaveType> GetLeaveTypeWithDetails(int id);
    Task<List<LeaveType>> GetLeaveAllocationsWithDetails();
}