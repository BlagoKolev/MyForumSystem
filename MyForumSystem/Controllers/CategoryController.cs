using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Services;

namespace MyForumSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult AllPosts(int categoryId, string categoryName)
        {
            var posts = categoryService.GetAllPosts(categoryId);

            if (posts == null)
            {
                return NotFound();
            }
            posts.CategoryId = categoryId;
            ViewData["categoryName"] = categoryName;
            return this.View(posts); 
        }
    }
}
