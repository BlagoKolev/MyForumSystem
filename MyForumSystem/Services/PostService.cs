using MyForumSystem.Data;
using MyForumSystem.Data.Models;
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

        public async Task<int> CreatePost(CreatePostViewModel inputModel, string userId)
        {
            var newPost = new Post
            {
                Title = inputModel.Title,
                Contents = inputModel.Contents,
                CreatorId = userId,
                Creator = this.db.Users.Where(x => x.Id == userId).FirstOrDefault(),
                CategoryId = inputModel.CategoryId,
                Category = this.db.Categories.Where(x => x.Id == inputModel.CategoryId).FirstOrDefault(),
                CreatedOn = DateTime.UtcNow,
            };

            await this.db.Posts.AddAsync(newPost);
            await this.db.SaveChangesAsync();
            
            return newPost.Id;
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
