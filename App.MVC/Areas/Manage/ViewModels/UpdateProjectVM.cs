namespace App.MVC.Areas.Manage.ViewModels
{
    public class UpdateProjectVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
    }
}
