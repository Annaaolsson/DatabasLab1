namespace DatabasLab1.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public string UserName { get; set; } = "";
        public string RestaurantName { get; set; } = "";
        public int Rating { get; set; }
    }
}