using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, bool>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        // retrieve leaveType
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.leaveAllocationId);

        // Verify if exists
        if (leaveAllocation == null)
        {
            throw new NotFoundException(nameof(LeaveAllocation), request.leaveAllocationId);
        }

        // Delete
        await _leaveAllocationRepository.DeleteAsync(leaveAllocation);

        return true;
    }
}
