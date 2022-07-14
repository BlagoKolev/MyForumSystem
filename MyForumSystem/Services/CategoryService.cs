using MyForumSystem.Data;
using static MyForumSystem.Data.GlobalConstants;
using MyForumSystem.Models.Categories;

namespace MyForumSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyForumDbContext db;

        public CategoryService(MyForumDbContext db)
        {
            this.db = db;
        }
        public ICollection<CategoryIndexViewModel> GetAllCategories()
        {
            var categories = db.Categories
                .Where(x => !x.IsDeleted)
                .Select(x => new CategoryIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    CreatedOn = x.CreatedOn.ToLocalTime(),
                })
                .ToList();
            return categories;
        }

        public CategoryAllPostViewModel GetAllPosts(int categoryId, int pageNumber)
        {
            var posts = db.Posts
                 .Where(x => !x.IsDeleted && x.CategoryId == categoryId && x.IsApproved)
                 .OrderByDescending(x => x.CreatedOn)
                 .Skip(((pageNumber - 1) * ItemsPerPage))
                 .Take(ItemsPerPage)
                 .Select(x => new CategoryPostViewModel
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Contents = x.Contents,
                     CreatorId = x.CreatorId,
                     CategoryId = categoryId,
                     CategoryName = x.Category.Name,
                     CreatedOn = x.CreatedOn.ToLocalTime(),
                     ModifiedOn = x.ModifiedOn.ToLocalTime(),
                 })
                 .ToList();

            var postsList = new CategoryAllPostViewModel
            {
                Posts = posts,
            };

            return postsList;
        }

        public int GetPostsCount(int categoryId)
        {
            return db.Posts.Where(x=>x.CategoryId == categoryId).Count();
        }
    }
}
