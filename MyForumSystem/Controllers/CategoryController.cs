using Microsoft.AspNetCore.Mvc;

namespace MyForumSystem.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {

        }

        public IActionResult AllPosts(string categoryName)
        {
            return this.View(); 
        }
    }
}
