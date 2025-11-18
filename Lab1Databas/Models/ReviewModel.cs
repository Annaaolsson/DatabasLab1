namespace DatabasLab1.Models
{
	public class ReviewModel
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }

        public ReviewModel()
		{	
		}
		
		public ReviewModel(int reviewId, int userId, int restaurantId, int rating)
        {
            ReviewId = reviewId;
			UserId = userId;
            RestaurantId = restaurantId;
			Rating = rating;
        }
    }
}