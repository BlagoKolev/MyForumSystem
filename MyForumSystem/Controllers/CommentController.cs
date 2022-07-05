using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Models.Comments;
using MyForumSystem.Models.Posts;
using MyForumSystem.Services;

namespace MyForumSystem.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICommentService commentService;

        public CommentController(UserManager<IdentityUser> userManager, ICommentService commentService)
        {
            this.userManager = userManager;
            this.commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return Redirect($"/Post/ById?postId={inputModel.PostId}");
            }

            inputModel.ParrentId = inputModel.ParrentId == 0 ? null : inputModel.ParrentId;
            var userId = GetUserId();
            await commentService.Create(userId, inputModel);

            return Redirect($"/Post/ById?postId={inputModel.PostId}");
        }

        private string GetUserId()
        {
            return userManager.GetUserId(this.User);
        }
    }
}
