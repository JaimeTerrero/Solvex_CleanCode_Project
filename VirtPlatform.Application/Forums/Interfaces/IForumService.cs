using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Forums.DTOs;

namespace VirtPlatform.Application.Forums.Interfaces
{
    public interface IForumService : IService<Forum, ForumDto>
    {
    }
}
