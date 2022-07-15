using MyForumSystem.Areas.Admin.Models.Posts;
using MyForumSystem.Models.Posts;

namespace MyForumSystem.Services
{
    public interface IAdminService
    {
        AllPostsApproveViewModel GetPostsToApprove();
        Task ApprovePost(int postId);
    }
}
