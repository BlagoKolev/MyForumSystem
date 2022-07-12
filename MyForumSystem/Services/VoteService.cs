using MyForumSystem.Data;
using MyForumSystem.Data.Models;
using MyForumSystem.Models.Votes;

namespace MyForumSystem.Services
{
    public class VoteService : IVoteService
    {
        private readonly MyForumDbContext db;

        public VoteService(MyForumDbContext db)
        {
            this.db = db;
        }
       
        public async Task<VotesCountJsonViewModel> MakeVote(int postId, bool isVotePositive, string userId)
        {
            var newVote = new Vote
            {
                PostId = postId,
                UserId = userId
            };
            if (isVotePositive)
            {
                newVote.Positive = true;
            }
            else
            {
                newVote.Negative = true;
            }

            var existedVote = db.Votes
                .Where(x => x.PostId == postId && x.UserId == userId)
                .FirstOrDefault();

            if (existedVote != null)
            {
                existedVote.Positive = newVote.Positive;
                existedVote.Negative = newVote.Negative;
            }
            else
            {
                await db.AddAsync(newVote);
            }
            await db.SaveChangesAsync();

            var postVotesCount = GetPostVotes(postId);
            return postVotesCount;
        }

        private VotesCountJsonViewModel GetPostVotes(int postId)
        {
            var postVotesCount = db.Posts
                 .Where(x => x.Id == postId)
                 .Select(x => new VotesCountJsonViewModel
                 {
                     Positive = x.Votes.Where(x => x.Positive == true).Count(),
                     Negative = x.Votes.Where(x => x.Negative == true).Count(),
                     TotalCount = x.Votes.Count()
                 })
                 .FirstOrDefault();
            return postVotesCount;
        }
    }
}
