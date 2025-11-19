using System.ComponentModel.DataAnnotations;

namespace DatabasLab1.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public string UserName { get; set; } = "";
        public string RestaurantName { get; set; } = "";

		[Range (1, 5, ErrorMessage = "Betyget måste vara mellan 1 och 5")]
        public int Rating { get; set; }
    }
}