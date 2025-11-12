namespace DatabasLab1.Models
{
	public class Restaurant
	{
		public int RestaurantId { get; set; }
		public string RestaurantName { get; set; }
		public string City { get; set; }

		// Konstruktor utan parametrar – sätter standardvärden
        public Restaurant()
        {
            RestaurantName = "Unknownestaurant";
            City = "UnknownCity";
        }

		// Konstruktor med alla attribut som inparametrar
		public Restaurant(int RestaurantId, string RestaurantName, string City)
		{
			RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            City = city;
		}
	}
}