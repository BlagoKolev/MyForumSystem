using MyForumSystem.Data;
using MyForumSystem.Data.Models;
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
                    CreatedOn = x.CreatedOn,
                })
                .ToList();
            return categories;
        }

        public CategoryAllPostViewModel GetAllPosts(int categoryId)
        {
            var posts = db.Posts
                 .Where(x => !x.IsDeleted && x.CategoryId == categoryId)
                 .Select(x => new CategoryPostViewModel
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Contents = x.Contents,
                     CreatorId = x.CreatorId,
                     CategoryId = categoryId,
                     CategoryName = x.Category.Name,
                     CreatedOn = x.CreatedOn,
                     ModifiedOn = x.ModifiedOn,
                 })
                 .OrderByDescending(x=>x.CreatedOn)
                 .ToList();

            var postsList = new CategoryAllPostViewModel
            {
                Posts = posts,
            };

            return postsList;
        }
    }
}
