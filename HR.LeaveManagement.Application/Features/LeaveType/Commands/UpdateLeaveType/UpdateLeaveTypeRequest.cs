using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeRequest
{
    public UpdateLeaveTypeRequest(int id, string name, int defaultDays)
    {
        Id = id;
        Name = name;
        DefaultDays = defaultDays;
    }

    public UpdateLeaveTypeRequest()
    {
        
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
