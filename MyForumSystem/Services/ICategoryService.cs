using MyForumSystem.Data.Models;
using MyForumSystem.Models.Categories;

namespace MyForumSystem.Services
{
    public interface ICategoryService
    {
        ICollection<CategoryIndexViewModel> GetAllCategories();
    }
}
