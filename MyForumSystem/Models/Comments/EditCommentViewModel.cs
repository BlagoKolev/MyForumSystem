namespace MyForumSystem.Models.Comments
{
    public class EditCommentViewModel
    {
        public int Id { get; set; }
        public string? Contents { get; set; }
        public int PostId { get; set; }
    }
}
