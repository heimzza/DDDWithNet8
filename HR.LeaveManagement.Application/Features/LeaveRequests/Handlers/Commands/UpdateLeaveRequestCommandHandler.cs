using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveRequestDtoValidator(_repository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        
        var leaveRequest = await _repository.GetAsync(request.Id);
        
        if (request.LeaveRequestDto != null)
        {
            leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
        
            await _repository.UpdateAsync(leaveRequest);
        }
        else if (request.ChangeLeaveRequestApprovalDto != null)
        {   
            await _repository.ChangeApprovalStatusAsync(leaveRequest, request.ChangeLeaveRequestApprovalDto.IsApproved);
        }
        
        return Unit.Value;
    }
}