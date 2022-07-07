using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Models.Posts;
using MyForumSystem.Services;

namespace MyForumSystem.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly UserManager<IdentityUser> userManager;

        public PostController(IPostService postService, UserManager<IdentityUser> userManager)
        {
            this.postService = postService;
            this.userManager = userManager;
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

        [HttpGet]
        [Authorize]
        public IActionResult Create(int categoryId)
        {
            var newPost = new CreatePostViewModel()
            {
                CategoryId = categoryId,
            };

            return this.View(newPost);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            var userId = GetUserId();
            var postId = await postService.CreatePost(inputModel, userId);

            return RedirectToAction(nameof(ById), new { postId });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int postId)
        {
            var postToEdit = postService.GetPostByIdToEdit(postId);
            if (postToEdit == null)
            {
                return NotFound();
            }
            return this.View(postToEdit);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditPostViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), new { postId = inputModel.Id });
            }
           await postService.EditPost(inputModel);
            return RedirectToAction(nameof(ById), new {postId = inputModel.Id});
        }

        private string GetUserId()
        {
            return this.userManager.GetUserId(this.User);
        }


    }
}
