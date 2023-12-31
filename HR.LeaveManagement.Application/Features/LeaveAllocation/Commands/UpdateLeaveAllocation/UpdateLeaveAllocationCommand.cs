﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommand : IRequest<bool>
{
    public UpdateLeaveAllocationCommand(int id, int numberOfDays, int leaveTypeId, int period, string employeeId)
    {
        Id = id;
        NumberOfDays = numberOfDays;
        LeaveTypeId = leaveTypeId;
        Period = period;
        EmployeeId = employeeId;
    }

    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; }
}
