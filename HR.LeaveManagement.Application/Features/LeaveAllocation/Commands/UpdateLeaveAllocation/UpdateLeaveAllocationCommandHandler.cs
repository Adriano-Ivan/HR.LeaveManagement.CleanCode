using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public sealed class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, bool>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, 
        IMapper mapper, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
        this._logger = logger;
    }

    public async Task<bool> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var validator = new UpdateLeaveAllocationCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}",
                nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid Leave Type", validationResult);

        }

        // Convert to entity
        var leaveAllocation= _mapper.Map<Domain.LeaveAllocation>(request);

        // Update
        await _leaveAllocationRepository.UpdateAsync(leaveAllocation);

        return true;
    }
}
