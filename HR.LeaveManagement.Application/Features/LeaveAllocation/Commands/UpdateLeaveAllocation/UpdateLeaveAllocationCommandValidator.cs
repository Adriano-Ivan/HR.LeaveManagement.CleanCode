﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
{
    public UpdateLeaveAllocationCommandValidator()
    {
        RuleFor(p => p.LeaveTypeId)
        .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(p => p.Period)
        .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(p => p.NumberOfDays)
        .NotNull().WithMessage("{PropertyName} is required");
    }
}
