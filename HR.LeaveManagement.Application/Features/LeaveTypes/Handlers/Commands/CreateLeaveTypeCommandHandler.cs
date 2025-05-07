using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(command.LeaveTypeDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Invalid leave type";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            
            return response;
        }
        
        var leaveType = _mapper.Map<LeaveType>(command);
        
        leaveType = await _repository.AddAsync(leaveType);
        
        response.Success = true;
        response.Message = "Created leave type";
        response.Id = leaveType.Id;
        return response;
    }
}