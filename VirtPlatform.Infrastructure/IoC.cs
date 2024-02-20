using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Domain.Interfaces.Repositories.Assignments;
using VirtPlatform.Domain.Interfaces.Repositories.Forums;
using VirtPlatform.Domain.Interfaces.Repositories.Subjects;
using VirtPlatform.Domain.Interfaces.Repositories.Users;
using VirtPlatform.Infrastructure.Repositories.Assignments;
using VirtPlatform.Infrastructure.Repositories.Forums;
using VirtPlatform.Infrastructure.Repositories.Subjects;
using VirtPlatform.Infrastructure.Repositories.Users;

namespace VirtPlatform.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISubjectRepository, SubjectRepository>()
                .AddScoped<IAssignmentRepository, AssignmentRepository>()
                .AddScoped<IForumRepository, ForumRepository>();
        }
    }
}
