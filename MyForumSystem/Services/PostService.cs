using MyForumSystem.Data;
using MyForumSystem.Models.Posts;

namespace MyForumSystem.Services
{
    public class PostService : IPostService
    {
        private readonly MyForumDbContext db;

        public PostService(MyForumDbContext db)
        {
            this.db = db;
        }
        public PostViewModel GetPostById(int postId)
        {
            var post = db.Posts
                .Where(x => x.Id == postId)
                .Select(x => new PostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Contents = x.Contents,
                    CategoryId = x.CategoryId,
                    CreatorId = x.CreatorId,
                    Creator = db.Users.Where(a => a.Id == x.CreatorId).FirstOrDefault(),
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    Comments = x.Comments,
                })
                .FirstOrDefault();
            return post;
        }
    }
}
