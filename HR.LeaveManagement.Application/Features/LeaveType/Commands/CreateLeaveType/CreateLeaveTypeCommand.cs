using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public CreateLeaveTypeCommand(string name, int defaultDays)
    {
        Name = name;
        DefaultDays = defaultDays;
    }

    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
