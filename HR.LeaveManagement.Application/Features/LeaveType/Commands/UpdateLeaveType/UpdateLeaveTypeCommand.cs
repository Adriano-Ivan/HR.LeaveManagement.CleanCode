
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<bool>
{
    public UpdateLeaveTypeCommand(int id, string name, int defaultDays)
    {
        Id = id;
        Name = name;    
        DefaultDays = defaultDays;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
