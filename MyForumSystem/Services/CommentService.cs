using MyForumSystem.Models.Comments;
using MyForumSystem.Data;
using MyForumSystem.Data.Models;

namespace MyForumSystem.Services
{
    public class CommentService : ICommentService
    {
        private readonly MyForumDbContext db;

        public CommentService(MyForumDbContext db)
        {
            this.db = db;
        }
        public async Task Create(string userId, CreateCommentInputModel inputModel)
        {
            var newComment = new Comment
            {
                Contents = inputModel.Contents,
                CreatorId = userId,
                ParrentId = inputModel.ParrentId,
                PostId = inputModel.PostId,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow
            };

            await this.db.Comments.AddAsync(newComment);
            await this.db.SaveChangesAsync();
        }

        public async Task<int> DeleteComment(int commentId)
        {
            var commentToDelete = db.Comments
                .Where(x => x.Id == commentId)
                .FirstOrDefault();
            commentToDelete.IsDeleted = true;

            await db.SaveChangesAsync();
            return commentToDelete.PostId;
        }

        public async Task EditComment(EditCommentViewModel inputModel)
        {
            var comment = db.Comments
                .Where(x => x.Id == inputModel.Id && !x.IsDeleted)
                .FirstOrDefault();
            comment.Contents = inputModel.Contents;
            comment.ModifiedOn = DateTime.UtcNow;
            await db.SaveChangesAsync();
        }

        public EditCommentViewModel GetById(int commentId)
        {
            var commentToEdit = db.Comments
                .Where(x => x.Id == commentId && !x.IsDeleted)
                .Select(x => new EditCommentViewModel
                {
                    Id = x.Id,
                    Contents = x.Contents,
                    PostId = x.PostId,
                })
                .FirstOrDefault();
            return commentToEdit;
        }
    }
}
