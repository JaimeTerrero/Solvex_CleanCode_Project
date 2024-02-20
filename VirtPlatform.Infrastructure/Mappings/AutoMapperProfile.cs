using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Assignments.DTOs;
using VirtPlatform.Application.Forums.DTOs;
using VirtPlatform.Application.Subjects.DTOs;
using VirtPlatform.Application.Users.DTOs;

namespace VirtPlatform.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>();

            CreateMap<SignUp, User>();

            CreateMap<LogIn, User>();

            CreateMap<AssignmentDto, Assignment>();

            CreateMap<SubjectDto, Subject>();

            CreateMap<ForumDto, Forum>();
        }
    }
}
