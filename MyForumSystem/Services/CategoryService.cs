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
            throw new NotImplementedException();
        }
    }
}
