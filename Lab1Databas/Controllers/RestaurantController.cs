using Microsoft.AspNetCore.Mvc;
using DatabasLab1.Models;

namespace DatabasLab1.Controllers
{
	public class RestaurantController : Controller 
	{

		static IList<RestaurantModel> restaurantList = new List<RestaurantModel>
		{
			new RestaurantModel() { RestaurantId = 1, RestaurantName = "Pizzerian", City = "Umeå"}, 
			new RestaurantModel() { RestaurantId = 2, RestaurantName = "Sushistället", City = "Stockholm"}, 
			new RestaurantModel() { RestaurantId = 3, RestaurantName = "Thaimaten", City = "Göteborg"}, 
			new RestaurantModel() { RestaurantId = 4, RestaurantName = "Steakhouse", City = "Malmö"}, 
		};


		public IActionResult Restaurants()
		{
			return View(restaurantList);
		}
	}
}