using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForumSystem.Data.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        public int? CommentId { get; set; }
        public Comment? Comment { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public bool Positive { get; set; }
        public bool Negative { get; set; }
    }
}
