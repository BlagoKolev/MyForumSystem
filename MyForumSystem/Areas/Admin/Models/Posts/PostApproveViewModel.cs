using Ganss.XSS;
using Microsoft.AspNetCore.Identity;

namespace MyForumSystem.Areas.Admin.Models.Posts
{
    public class PostApproveViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? SanitizedContents => new HtmlSanitizer().Sanitize(this.Contents);
        public string? CreatorId { get; set; }
        public IdentityUser Creator { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
