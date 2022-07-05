using System.ComponentModel.DataAnnotations;
using static MyForumSystem.Data.GlobalConstants;
namespace MyForumSystem.Models.Comments
{
    public class CreateCommentViewModel
    {
        [Required]
        [MinLength(ContentsMinLength, ErrorMessage = FieldMinLength)]
        [MaxLength(ContentsMaxLength, ErrorMessage = FieldMaxLength)]
        public string? Contents { get; set; }
        [Required]
        public string? CreatorId { get; set; }
        [Required]
        public int PostId { get; set; }
        public int ParrentId { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
    }
}
