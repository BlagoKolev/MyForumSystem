namespace MyForumSystem.Models.Categories
{
    public class CategoryPostViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? CreatorId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
