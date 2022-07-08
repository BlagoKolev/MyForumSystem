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

        public IActionResult AllPosts(int categoryId, string categoryName, int pageNumber = 1)
        {
            var postsList = categoryService.GetAllPosts(categoryId, pageNumber);

            if (postsList == null)
            {
                return NotFound();
            }
            postsList.CurrentPage = pageNumber;
            postsList.ItemsCount = categoryService.GetPostsCount(categoryId);
            postsList.CategoryId = categoryId;
            ViewData["categoryName"] = categoryName;

            return this.View(postsList);
        }
    }
}
