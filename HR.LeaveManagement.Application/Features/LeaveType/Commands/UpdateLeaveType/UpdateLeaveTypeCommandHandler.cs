using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository 
        leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<bool> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var validator = new UpdateLeaveTypeCommandValidator(this._leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", 
                nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid Leave Type", validationResult);

        }

        // Convert to entity
        var leaveType = _mapper.Map<Domain.LeaveType>(request);

        // Update
        await _leaveTypeRepository.UpdateAsync(leaveType);  

        return true;
    }
}

