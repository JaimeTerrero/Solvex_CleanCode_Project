using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs.Assignments;
using VirtPlatform.Application.Users.DTOs.Subjects;

namespace VirtPlatform.Application.Users.Interfaces.Subjects
{
    public interface ISubjectService : IService<Subject, SubjectDto>
    {
    }
}
