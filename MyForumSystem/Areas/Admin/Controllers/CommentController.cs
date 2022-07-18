using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Services;

namespace MyForumSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly IAdminService adminService;

        public CommentController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var postsToApprove = adminService.GetCommentsToApprove();
            return View(postsToApprove);
        }
    }
}
