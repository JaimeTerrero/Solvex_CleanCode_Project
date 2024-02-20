﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs.Assignments;

namespace VirtPlatform.Application.Users.Interfaces.Assignments
{
    public interface IAssignmentService : IService<Assignment, AssignmentDto>
    {
    }
}
