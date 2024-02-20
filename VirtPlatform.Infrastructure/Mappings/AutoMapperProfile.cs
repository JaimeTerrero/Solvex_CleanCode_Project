using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs.Assignments;
using VirtPlatform.Application.Users.DTOs.Forums;
using VirtPlatform.Application.Users.DTOs.Subjects;
using VirtPlatform.Application.Users.DTOs.Users;

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
