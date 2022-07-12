using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyForumSystem.Models.Votes;
using MyForumSystem.Services;

namespace MyForumSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : Controller
    {
        private readonly IVoteService voteService;
        private readonly UserManager<IdentityUser> userManager;

        public VoteController(IVoteService voteService, UserManager<IdentityUser> userManager)
        {
            this.voteService = voteService;
            this.userManager = userManager;
        }
       
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MakeVote(VoteInputModel inputModel)
        {
            var userId = GetUserId();
            var postVotesCount = await voteService.MakeVote(inputModel.PostId, inputModel.IsVotePositive, userId);
            return Json(postVotesCount);
        }
        private string GetUserId()
        {
            return userManager.GetUserId(this.User);
        }
    }
}
