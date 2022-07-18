namespace MyForumSystem.Areas.Admin.Models.Comments
{
    public class AllCommentsApproveViewModel
    {
        public AllCommentsApproveViewModel()
        {
            this.comments = new List<CommentApproveViewModel>();
        }
        public ICollection<CommentApproveViewModel> comments { get; set; }
    }
}
