using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper,
        IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _emailSender = emailSender;
    }
    
    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Invalid leave request";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            return response;
        }
        
        var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
        
        await _leaveRequestRepository.AddAsync(leaveRequest);
        
        response.Success = true;
        response.Message = "Leave Request Created Successfully";
        response.Id = leaveRequest.Id;

        var email = new Email
        {
            To = "employee@gmail.com",
            Body = $"Leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
                   $"has been submitted successfully.",
            Subject = "Leave Request Submitted"
        };

        try
        {
            await _emailSender.SendEmail(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // log with logger
        }

        return response;
    }
}