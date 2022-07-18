using Ganss.XSS;
using Microsoft.AspNetCore.Identity;

namespace MyForumSystem.Areas.Admin.Models.Comments
{
    public class CommentApproveViewModel
    {
        public int Id { get; set; }
        public string? Contents { get; set; }
        public string? SanitizedContents => new HtmlSanitizer().Sanitize(this.Contents);
        public string? CreatorId { get; set; }
        public IdentityUser Creator { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int PostId { get; set; }
    }
}
