using MyForumSystem.Models.Comments;

namespace MyForumSystem.Services
{
    public interface ICommentService
    {
        Task Create(string userId, CreateCommentInputModel inputModel);
        EditCommentViewModel GetById(int commentId);
        Task EditComment(EditCommentViewModel inputModel);
    }
}
