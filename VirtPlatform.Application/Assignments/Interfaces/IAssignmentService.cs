using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Assignments.DTOs;

namespace VirtPlatform.Application.Assignments.Interfaces
{
    public interface IAssignmentService : IService<Assignment, AssignmentDto>
    {
    }
}
