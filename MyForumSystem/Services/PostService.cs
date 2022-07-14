using MyForumSystem.Data;
using MyForumSystem.Data.Models;
using MyForumSystem.Models.Posts;
using MyForumSystem.Models.Comments;
using System.Globalization;

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
                ModifiedOn = DateTime.UtcNow,
            };

            await db.Posts.AddAsync(newPost);
            await db.SaveChangesAsync();

            return newPost.Id;
        }

        public async Task DeletePost(int postId)
        {
            var postToDelete = db.Posts
                .Where(x => x.Id == postId)
                .FirstOrDefault();

            postToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

        }

        public async Task EditPost(EditPostViewModel inputModel)
        {
            var post = db.Posts
                .Where(x => x.Id == inputModel.Id && x.IsDeleted == false)
               .FirstOrDefault();

            post.Title = inputModel.Title;
            post.Contents = inputModel.Contents;
            post.ModifiedOn = DateTime.UtcNow;

            await db.SaveChangesAsync();
        }

        public PostViewModel GetPostById(int postId)
        {
            var post = db.Posts
                .Where(x => x.Id == postId && x.IsApproved)
                .Select(x => new PostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Contents = x.Contents,
                    CategoryId = x.CategoryId,
                    CreatorId = x.CreatorId,
                    Creator = db.Users.Where(a => a.Id == x.CreatorId).FirstOrDefault(),
                    CreatedOn = x.CreatedOn.ToLocalTime(),
                    ModifiedOn = x.ModifiedOn.ToLocalTime(),
                    Comments = x.Comments
                    .Where(x => !x.IsDeleted && x.IsApproved)
                    .Select(x => new PostCommentsViewModel
                    {
                        Id = x.Id,
                        CreatorId = x.CreatorId,
                        Creator = x.Creator,
                        Contents = x.Contents,
                        ParrentId = x.ParrentId,
                        PostId = x.PostId,
                        CreatedOn = x.CreatedOn,
                        ModifiedOn = x.ModifiedOn
                    })
                    .OrderByDescending(x => x.CreatedOn)
                    .ToList(),
                    Votes = x.Votes
                })
                .FirstOrDefault();
            return post;
        }

        public EditPostViewModel GetPostByIdToEdit(int postId)
        {
            var postToEdit = db.Posts
                .Where(x => x.Id == postId)
                .Select(x => new EditPostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Contents = x.Contents,
                    CategoryId = x.CategoryId,
                    CreatorId = x.CreatorId,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                })
                .FirstOrDefault();

            return postToEdit;
        }
    }
}
