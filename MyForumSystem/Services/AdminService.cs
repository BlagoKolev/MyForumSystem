using MyForumSystem.Areas.Admin.Models.Comments;
using MyForumSystem.Areas.Admin.Models.Posts;

namespace MyForumSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly MyForumDbContext db;

        public AdminService(MyForumDbContext db)
        {
            this.db = db;
        }
        public async Task ApproveComment(int commentId)
        {
            var commentToApprove = db.Comments
                .Where(x => !x.IsApproved && !x.IsDeleted)
                .FirstOrDefault();
            if (commentToApprove == null)
            {
                return;
            }
            commentToApprove.IsApproved = true;
            commentToApprove.ApprovedOn = DateTime.UtcNow;
            await db.SaveChangesAsync();
        }

        public async Task ApprovePost(int postId)
        {
            var postToApprove = db.Posts
                .Where(x => x.Id == postId)
                .FirstOrDefault();
            if (postToApprove == null)
            {
                return;
            }
            postToApprove.IsApproved = true;
            postToApprove.ApprovedOn = DateTime.UtcNow;
            await db.SaveChangesAsync();
        }

        public async Task DeclineComment(int commentId)
        {
            var commentToDecline = db.Comments
                .Where(x => x.Id == commentId)
                .FirstOrDefault();
            if (commentToDecline == null)
            {
                return;
            }
            commentToDecline.IsDeleted = true;
            await db.SaveChangesAsync();
        }

        public async Task DeclinePost(int postId)
        {
            var postToDecline = db.Posts
               .Where(x => x.Id == postId)
               .FirstOrDefault();
            if (postToDecline == null)
            {
                return;
            }
            postToDecline.IsDeleted = true;
            await db.SaveChangesAsync();
        }
        public AllCommentsApproveViewModel GetCommentsToApprove()
        {
            var commentsToApprove = db.Comments
                  .Where(x => !x.IsApproved && !x.IsDeleted)
                  .Select(x => new CommentApproveViewModel
                  {
                      Id = x.Id,
                      PostId = x.PostId,
                      CategoryId = x.Post.CategoryId,
                      CategoryName = x.Post.Category.Name,
                      Contents = x.Contents,
                      CreatorId = x.CreatorId,
                      Creator = x.Creator,
                      CreatedOn = x.CreatedOn,
                      ModifiedOn = x.ModifiedOn,

                  })
                 .ToList();
            return new AllCommentsApproveViewModel() { comments = commentsToApprove };
        }

        public AllPostsApproveViewModel GetPostsToApprove()
        {
            var posts = db.Posts
               .Where(x => !x.IsApproved && !x.IsDeleted)
               .Select(x => new PostApproveViewModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   Contents = x.Contents,
                   CategoryId = x.CategoryId,
                   CategoryName = x.Category.Name,
                   CreatorId = x.CreatorId,
                   Creator = db.Users.Where(a => a.Id == x.CreatorId).FirstOrDefault(),
                   CreatedOn = x.CreatedOn.ToLocalTime(),
                   ModifiedOn = x.ModifiedOn.ToLocalTime()
               })
               .ToList();

            AllPostsApproveViewModel allPostToApprove = new AllPostsApproveViewModel();
            allPostToApprove.posts = posts;

            return allPostToApprove;
        }
    }
}
