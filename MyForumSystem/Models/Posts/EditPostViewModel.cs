using System.ComponentModel.DataAnnotations;
using static MyForumSystem.Data.GlobalConstants;

namespace MyForumSystem.Models.Posts
{
    public class EditPostViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(TitleMinLength, ErrorMessage = FieldMinLength)]
        [MaxLength(TitleMaxLength, ErrorMessage = FieldMaxLength)]
        public string? Title { get; set; }

        [Required]
        [MinLength(ContentsMinLength, ErrorMessage = FieldMinLength)]
        [MaxLength(ContentsMaxLength, ErrorMessage = FieldMaxLength)]
        public string? Contents { get; set; }

        public string? CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
