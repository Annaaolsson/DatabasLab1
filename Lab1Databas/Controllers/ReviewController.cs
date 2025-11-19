using Microsoft.AspNetCore.Mvc;
using DatabasLab1.Models;
using System.Linq;

namespace DatabasLab1.Controllers
{
	public class ReviewController : Controller 
	{

		static IList<ReviewModel> reviewList = new List<ReviewModel>
		{
			new ReviewModel() { ReviewId = 1, UserId = 1, RestaurantId = 2, Rating = 4}, 
			new ReviewModel() { ReviewId = 2, UserId = 2, RestaurantId = 4, Rating = 3}, 
			new ReviewModel() { ReviewId = 3, UserId = 3, RestaurantId = 3, Rating = 1}, 
			new ReviewModel() { ReviewId = 4, UserId = 4, RestaurantId = 1, Rating = 5},
			new ReviewModel() { ReviewId = 5, UserId = 3, RestaurantId = 2, Rating = 4},
			new ReviewModel() { ReviewId = 6, UserId = 1, RestaurantId = 4, Rating = 2}, 
		};

		static IList<UserModel> userList = new List<UserModel>
        {
            new UserModel(1, "Ella", "Strand"),
            new UserModel(2, "Lisa", "Sjöström"),
            new UserModel(3, "John", "Andersson"),
            new UserModel(4, "Sven", "Olsson")
        };

		static IList<RestaurantModel> restaurantList = new List<RestaurantModel>
		{
			new RestaurantModel() { RestaurantId = 1, RestaurantName = "Pizzerian", City = "Umeå"}, 
			new RestaurantModel() { RestaurantId = 2, RestaurantName = "Sushistället", City = "Stockholm"}, 
			new RestaurantModel() { RestaurantId = 3, RestaurantName = "Thaimaten", City = "Göteborg"}, 
			new RestaurantModel() { RestaurantId = 4, RestaurantName = "Steakhouse", City = "Malmö"}, 
		};


		public IActionResult Reviews()
        {
            if(HttpContext.Session.GetString("UserName") == null)
			{
				return RedirectToAction("Login", "Home");
			}
			
			// Bygg om varje ReviewModel → ReviewViewModel
            var viewModelList = reviewList
                .Select(r =>
                {
                    var user = userList.FirstOrDefault(u => u.UserId == r.UserId);
                    var restaurant = restaurantList.FirstOrDefault(res => res.RestaurantId == r.RestaurantId);

                    return new ReviewViewModel
                    {
                        ReviewId = r.ReviewId,
                        Rating = r.Rating,
                        UserName = user != null ? $"{user.FirstName} {user.LastName}" : "Okänd användare",
                        RestaurantName = restaurant != null ? restaurant.RestaurantName : "Okänd restaurang"
                    };
                })
                .ToList();

            return View(viewModelList);
		}

		[HttpGet]
		public IActionResult EditReview(int reviewId)
		{
			var review = reviewList.FirstOrDefault(r => r.ReviewId == reviewId);
			if (review == null)
			{
				return NotFound();
			}

			var user = userList.FirstOrDefault(u => u.UserId == review.UserId);
			var restaurant = restaurantList.FirstOrDefault(r => r.RestaurantId == review.RestaurantId);

			var vm = new ReviewViewModel
			{
				ReviewId = review.ReviewId,
				UserName = user != null ? $"{user.FirstName} {user.LastName}" : "",
				RestaurantName = restaurant != null ? restaurant.RestaurantName : "",
				Rating = review.Rating
			};

			return View(vm);
		}


		[HttpPost]
		public IActionResult EditReview(ReviewViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var review = reviewList.FirstOrDefault(r => r.ReviewId == model.ReviewId);
			if (review == null)
			{
				return NotFound();
			}

			review.Rating = model.Rating;

			return RedirectToAction("Reviews");
		}
	}
}