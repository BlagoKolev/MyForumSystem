using MyForumSystem.Data;

namespace MyForumSystem.Models
{
    public class PagingViewModel
    {
        public int ItemsCount { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage => CurrentPage - 1;
        public int NextPage => CurrentPage + 1;
        public int ItemsPerPage { get; set; } = GlobalConstants.ItemsPerPage;
        public int PagesCount => (int)Math.Ceiling((double)ItemsCount / ItemsPerPage);
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < PagesCount;
    }
}
