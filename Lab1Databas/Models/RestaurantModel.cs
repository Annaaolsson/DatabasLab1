namespace DatabasLab1.Models
{
	public class RestaurantModel
	{
		public int RestaurantId { get; set; }
		public string RestaurantName { get; set; }
		public string City { get; set; }

		// Konstruktor utan parametrar – sätter standardvärden
        public RestaurantModel()
        {
            RestaurantName = "UnknownRestaurant";
            City = "UnknownCity";
        }

		// Konstruktor med alla attribut som inparametrar
		public RestaurantModel(int restaurantId, string restaurantName, string city)
		{
			RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            City = city;
		}
	}
}