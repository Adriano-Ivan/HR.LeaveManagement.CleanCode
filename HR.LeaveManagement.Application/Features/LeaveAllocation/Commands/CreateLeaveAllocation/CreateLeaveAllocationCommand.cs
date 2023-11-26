using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public CreateLeaveAllocationCommand(int numberOfDays, int leaveTypeId, int period, string employeeId)
    {
        NumberOfDays = numberOfDays;
        LeaveTypeId = leaveTypeId;
        Period = period;
        EmployeeId = employeeId;
    }

    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; }
}
