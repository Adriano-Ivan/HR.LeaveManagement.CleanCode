using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryRequestHandler : IRequestHandler<GetLeaveTypeDetailsQueryRequest,
                                                    LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsQueryRequestHandler(IMapper mapper, ILeaveTypeRepository 
        leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        // Get LeaveType
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.leaveTypeId);

        if(leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.leaveTypeId);
        }

        // Convert to DTO
        var leaveTypeDto = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

        // return LeaveType DTO
        return leaveTypeDto;
    }
}

