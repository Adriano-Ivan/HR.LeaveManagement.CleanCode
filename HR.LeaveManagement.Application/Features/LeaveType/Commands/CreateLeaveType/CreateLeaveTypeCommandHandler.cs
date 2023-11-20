using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository 
        leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validaste incoming data
        var validator = new CreateLeaveTypeCommandValidator(this._leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);   

        if(validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Leave Type", validationResult);
        }

        // Convert request to domain entity
        var leaveType = _mapper.Map<Domain.LeaveType>(request);

        // Insert entity
        var createdLeaveType = await _leaveTypeRepository.CreateAsync(leaveType);

        // return id
        return createdLeaveType.Id;
    }
}

