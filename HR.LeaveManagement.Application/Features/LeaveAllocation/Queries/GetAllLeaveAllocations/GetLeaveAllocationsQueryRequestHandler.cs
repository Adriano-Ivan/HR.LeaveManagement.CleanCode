using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public sealed class GetLeaveAllocationsQueryRequestHandler : IRequestHandler<GetLeaveAllocationsQueryRequest,
                                                                List<LeaveAllocationDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IAppLogger<GetLeaveAllocationsQueryRequestHandler> _logger;

    public GetLeaveAllocationsQueryRequestHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, 
        IAppLogger<GetLeaveAllocationsQueryRequestHandler> logger)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _logger = logger;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQueryRequest request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveAllocations = await _leaveAllocationRepository.GetAllAsync();

        // Convert data objects to DTO objects
        List<LeaveAllocationDto> leaveAllocationsDto = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        // return list of DTO Object
        _logger.LogInformation("Leave allocations were retrieved successfully");
        return leaveAllocationsDto;
    }
}
