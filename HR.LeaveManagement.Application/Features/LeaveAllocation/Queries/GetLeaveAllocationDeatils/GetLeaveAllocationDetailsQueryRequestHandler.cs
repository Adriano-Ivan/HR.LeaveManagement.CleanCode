using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDeatils;

public sealed class GetLeaveAllocationDetailsQueryRequestHandler : IRequestHandler<GetLeaveAllocationDetailsQueryRequest,
                                                                    LeaveAllocationDetailsDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailsQueryRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        // Get LeaveAllocation
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.leaveAllocationId);

        if (leaveAllocation == null)
        {
            throw new NotFoundException(nameof(LeaveAllocation), request.leaveAllocationId);
        }

        // Convert to DTO
        var leaveAllocationDto = _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);

        // return LeaveType DTO
        return leaveAllocationDto;
    }
}
