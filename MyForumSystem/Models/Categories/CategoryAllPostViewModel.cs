namespace MyForumSystem.Models.Categories
{
    public class CategoryAllPostViewModel
    {
        public CategoryAllPostViewModel()
        {
            this.Posts = new HashSet<CategoryPostViewModel>();
        }
        public ICollection<CategoryPostViewModel> Posts { get; set; }
    }
}
