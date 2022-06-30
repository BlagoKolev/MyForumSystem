namespace MyForumSystem.Models.Categories
{
    public class CategoryIndexViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
