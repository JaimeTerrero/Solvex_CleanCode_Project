using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Assignments.Interfaces;
using VirtPlatform.Application.Assignments.Services;
using VirtPlatform.Application.Forums.Interfaces;
using VirtPlatform.Application.Forums.Services;
using VirtPlatform.Application.Subjects.Interfaces;
using VirtPlatform.Application.Subjects.Services;
using VirtPlatform.Application.Users.Interfaces;
using VirtPlatform.Application.Users.Services;

namespace VirtPlatform.Application
{
    public static class IoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserService, UserService>()
                .AddScoped<ISubjectService, SubjectService>()
                .AddScoped<IAssignmentService, AssignmentService>()
                .AddScoped<IForumService, ForumService>();
        }
    }
}
