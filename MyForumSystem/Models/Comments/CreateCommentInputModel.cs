using System.ComponentModel.DataAnnotations;
using static MyForumSystem.Data.GlobalConstants;
namespace MyForumSystem.Models.Comments
{
    public class CreateCommentInputModel
    {
        [Required]
        [MinLength(ContentsMinLength, ErrorMessage = FieldMinLength)]
        [MaxLength(ContentsMaxLength, ErrorMessage = FieldMaxLength)]
        public string? Contents { get; set; }
        public string? CreatorId { get; set; }
        public int PostId { get; set; }
        public int? ParrentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
