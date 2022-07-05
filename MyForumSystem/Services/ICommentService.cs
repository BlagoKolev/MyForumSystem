using MyForumSystem.Models.Comments;

namespace MyForumSystem.Services
{
    public interface ICommentService
    {
        Task Create(string userId, CreateCommentInputModel inputModel);
    }
}
