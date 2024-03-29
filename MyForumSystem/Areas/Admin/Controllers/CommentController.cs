﻿using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> ApproveComment(int commentId)
        {
            await adminService.ApproveComment(commentId);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> DeclineComment(int commentId)
        {
            await adminService.DeclineComment(commentId);
            return RedirectToAction(nameof(All));
        }
    }
}
