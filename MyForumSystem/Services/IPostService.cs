using MyForumSystem.Models.Posts;

namespace MyForumSystem.Services
{
    public interface IPostService
    {
        PostViewModel GetPostById(int postId);
    }
}
