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
			if(HttpContext.Session.GetString("UserName") == null)
			{
				return RedirectToAction("Login", "Home");
			}
			
			return View(restaurantList);
		}

		public IActionResult AddRestaurant()
		{
			return View(new RestaurantModel());
		}

		[HttpPost]
		public IActionResult AddRestaurant(RestaurantModel restaurant)
		{
			restaurantList.Add(restaurant);
			return RedirectToAction("Restaurants");
		}

		[HttpGet]
		public IActionResult EditRestaurant(int RestaurantId)
		{
			var restaurant = restaurantList.Where(r => r.RestaurantId == RestaurantId).FirstOrDefault();

			return View(restaurant);
		}

		[HttpPost]
		public IActionResult EditRestaurant(RestaurantModel restaurant)
		{
			var existingRestaurant = restaurantList.FirstOrDefault(r => r.RestaurantId == restaurant.RestaurantId);

			if(existingRestaurant != null)
			{
				existingRestaurant.RestaurantName = restaurant.RestaurantName;
				existingRestaurant.City = restaurant.City;
			}

			return RedirectToAction("Restaurants");
		}

		[HttpGet]
		public IActionResult DeleteRestaurant(int RestaurantId)
		{
			var restaurant = restaurantList.FirstOrDefault(r => r.RestaurantId == RestaurantId);

			if(restaurant == null){
				return NotFound();
			}

			return View(restaurant);
		}

		[HttpPost]
		public IActionResult DeleteRestaurantConfirmed(int RestaurantId)
		{
			var restaurant = restaurantList.FirstOrDefault(r => r.RestaurantId == RestaurantId);

			if(restaurant != null)
			{
				restaurantList.Remove(restaurant);
			}

			return RedirectToAction("Restaurants");
		}
	}
	
}