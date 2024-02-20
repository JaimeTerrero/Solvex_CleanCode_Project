using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Subjects.DTOs;

namespace VirtPlatform.Application.Subjects.Interfaces
{
    public interface ISubjectService : IService<Subject, SubjectDto>
    {
    }
}
