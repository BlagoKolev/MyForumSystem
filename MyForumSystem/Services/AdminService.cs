using MyForumSystem.Areas.Admin.Models.Posts;
using MyForumSystem.Data;
using MyForumSystem.Models.Posts;

namespace MyForumSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly MyForumDbContext db;

        public AdminService(MyForumDbContext db)
        {
            this.db = db;
        }
        public AllPostsApproveViewModel GetPostsToApprove()
        {
            var posts = db.Posts
               .Where(x => !x.IsApproved)
               .Select(x => new PostApproveViewModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   Contents = x.Contents,
                   CategoryId = x.CategoryId,
                   CreatorId = x.CreatorId,
                   Creator = db.Users.Where(a => a.Id == x.CreatorId).FirstOrDefault(),
                   CreatedOn = x.CreatedOn.ToLocalTime(),
                   ModifiedOn = x.ModifiedOn.ToLocalTime(),                  
               })
               .ToList();

            AllPostsApproveViewModel allPostToApprove = new AllPostsApproveViewModel();
            allPostToApprove.posts = posts;

            return allPostToApprove;
        }
    }
}
