using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Forum
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
