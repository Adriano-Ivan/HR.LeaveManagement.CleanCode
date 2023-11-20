using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository 
        leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // retrieve leaveType
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.leaveTypeId);

        // Verify if exists
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.leaveTypeId);
        }

        // Delete
        await _leaveTypeRepository.DeleteAsync(request.leaveTypeId);


        return Unit.Value;
    }
}

