using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs.Forums;

namespace VirtPlatform.Application.Users.Interfaces.Forums
{
    public interface IForumService : IService<Forum, ForumDto>
    {
    }
}
