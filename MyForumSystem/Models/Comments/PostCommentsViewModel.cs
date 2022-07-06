using Ganss.XSS;
using Microsoft.AspNetCore.Identity;

namespace MyForumSystem.Models.Comments
{
    public class PostCommentsViewModel
    {
        public int Id { get; set; }
        public string? Contents { get; set; }
        public string? SanitizedContents => new HtmlSanitizer().Sanitize(this.Contents);
        public string? CreatorId { get; set; }
        public IdentityUser Creator { get; set; }
        public int PostId { get; set; }
        public int? ParrentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
