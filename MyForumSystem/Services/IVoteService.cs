using MyForumSystem.Models.Votes;

namespace MyForumSystem.Services
{
    public interface IVoteService
    {
        Task<VotesCountJsonViewModel> MakeVote(int postId, bool isVotePositive, string userId);
    }
}
