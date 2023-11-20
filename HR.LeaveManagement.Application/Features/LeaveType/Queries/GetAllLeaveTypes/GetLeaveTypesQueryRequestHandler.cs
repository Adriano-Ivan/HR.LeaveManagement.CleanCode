using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryRequestHandler : IRequestHandler<GetLeaveTypesQueryRequest, 
                                            List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypesQueryRequestHandler(IMapper mapper, ILeaveTypeRepository
        leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQueryRequest request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();

        // Convert data objects to DTO objects
        List<LeaveTypeDto> leaveTypesDto = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

        // return list of DTO object
        return leaveTypesDto;
    }
}

