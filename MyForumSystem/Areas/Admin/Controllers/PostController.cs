using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Services;

namespace MyForumSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IAdminService adminService;

        public PostController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var posts = adminService.GetPostsToApprove();
            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovePost(int postId)
        {
           await adminService.ApprovePost(postId);
           return RedirectToAction(nameof(All));
        }
    }
}
