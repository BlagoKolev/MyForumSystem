using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Models.Comments;

namespace MyForumSystem.Controllers
{
    public class CommentController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(int Id, int parrentId, CreateCommentViewModel postModel)
        {
            if (!this.ModelState.IsValid)
            {
                return Redirect($"/Post/ById?postId={Id}");
            }
            return this.View();
        }
    }
}
