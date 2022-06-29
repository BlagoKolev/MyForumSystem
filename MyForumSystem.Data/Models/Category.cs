using System.ComponentModel.DataAnnotations;
using static MyForumSystem.Data.GlobalConstants;

namespace MyForumSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredFieldWarning)]
        [MinLength(TitleMinLength, ErrorMessage = FieldLengthWarning)]
        [MaxLength(TitleMaxLength, ErrorMessage = FieldLengthWarning)]
        public string? Name { get; set; }

        [Required(ErrorMessage = RequiredFieldWarning)]
        [MinLength(TitleMinLength, ErrorMessage = FieldLengthWarning)]
        [MaxLength(TitleMaxLength, ErrorMessage = FieldLengthWarning)]
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
