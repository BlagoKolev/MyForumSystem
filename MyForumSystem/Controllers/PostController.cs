using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Services;

namespace MyForumSystem.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult ById(int postId)
        {
            var post = postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return this.View(post);
        }
    }
}
