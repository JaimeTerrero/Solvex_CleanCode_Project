using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtPlatform.Application.Users.DTOs.Forums
{
    public class ForumDto
    {
        public string Content { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
    }
}
