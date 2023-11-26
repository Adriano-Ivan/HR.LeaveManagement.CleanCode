using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryRequestHandler : IRequestHandler<GetLeaveTypesQueryRequest, 
                                            List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<GetLeaveTypesQueryRequestHandler> _logger;

    public GetLeaveTypesQueryRequestHandler(IMapper mapper, ILeaveTypeRepository
        leaveTypeRepository, IAppLogger<GetLeaveTypesQueryRequestHandler> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQueryRequest request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();

        // Convert data objects to DTO objects
        List<LeaveTypeDto> leaveTypesDto = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

        // return list of DTO Object
        _logger.LogInformation("Leave types were retrieved successfully");
        return leaveTypesDto;
    }
}

