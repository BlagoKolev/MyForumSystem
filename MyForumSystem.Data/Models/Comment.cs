using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MyForumSystem.Data.GlobalConstants;


namespace MyForumSystem.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredFieldWarning)]
        [MinLength(ContentsMinLength, ErrorMessage = FieldMinLength)]
        [MaxLength(ContentsMaxLength, ErrorMessage = FieldMaxLength)]
        public string? Contents { get; set; }

        [Required]
        public string? CreatorId { get; set; }
        public IdentityUser Creator { get; set; }

        [Required]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int? ParrentId { get; set; }
        public virtual Comment? Parrent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedOn { get; set; } = null;
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
