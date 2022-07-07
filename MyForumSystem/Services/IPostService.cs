using MyForumSystem.Models.Posts;

namespace MyForumSystem.Services
{
    public interface IPostService
    {
        PostViewModel GetPostById(int postId);
        Task<int> CreatePost(CreatePostViewModel inputModel, string userId);
        EditPostViewModel GetPostByIdToEdit(int postId);
        Task EditPost(EditPostViewModel inputModel);
        Task DeletePost(int postId);
    }
}
