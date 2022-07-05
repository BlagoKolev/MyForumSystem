using Microsoft.AspNetCore.Identity;
using MyForumSystem.Data.Models;
using MyForumSystem.Models.Comments;

namespace MyForumSystem.Models.Posts
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? SanitizedContents { get; set; }
        public int? CategoryId { get; set; }
        public string? CreatorId { get; set; }
        public IdentityUser? Creator { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
