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
            };

            await this.db.Comments.AddAsync(newComment);
            await this.db.SaveChangesAsync();
        }
    }
}
