using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyForumSystem.Data.GlobalConstants;


namespace MyForumSystem.Data.Models
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredFieldWarning)]
        [MinLength(TitleMinLength, ErrorMessage = FieldMinLength)]
        [MaxLength(TitleMaxLength, ErrorMessage = FieldMaxLength)]
        public string? Title { get; set; }

        [Required(ErrorMessage = RequiredFieldWarning)]
        [MinLength(ContentsMinLength, ErrorMessage = FieldMinLength)]
        [MaxLength(ContentsMaxLength, ErrorMessage = FieldMaxLength)]
        public string? Contents { get; set; }

        [Required]
        public string? CreatorId { get; set; }
        public IdentityUser? Creator { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedOn { get; set; } = null;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }

    }
}
