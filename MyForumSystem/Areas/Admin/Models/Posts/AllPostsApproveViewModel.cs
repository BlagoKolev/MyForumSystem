namespace MyForumSystem.Areas.Admin.Models.Posts
{
    public class AllPostsApproveViewModel
    {
        public AllPostsApproveViewModel()
        {
            this.posts = new HashSet<PostApproveViewModel>();
        }
        public ICollection<PostApproveViewModel> posts { get; set; }
    }
}
