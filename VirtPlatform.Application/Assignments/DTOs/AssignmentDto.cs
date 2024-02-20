using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtPlatform.Application.Assignments.DTOs
{
    public class AssignmentDto
    {
        public string Title { get; set; }
        public DateTime DeliveryDeadLine { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
    }
}
