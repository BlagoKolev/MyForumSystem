using MyForumSystem.Areas.Admin.Models.Comments;
using MyForumSystem.Areas.Admin.Models.Posts;
using MyForumSystem.Models.Posts;

namespace MyForumSystem.Services
{
    public interface IAdminService
    {
        AllPostsApproveViewModel GetPostsToApprove();
        Task ApprovePost(int postId);
        Task DeclinePost(int postId);
        AllCommentsApproveViewModel GetCommentsToApprove();
        Task ApproveComment (int commentId);
        Task DeclineComment(int commentId); 
    }
}
