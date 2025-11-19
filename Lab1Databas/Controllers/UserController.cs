using Microsoft.AspNetCore.Mvc;
using DatabasLab1.Models;

namespace DatabasLab1.Controllers
{
	public class UserController : Controller 
	{

		static IList<UserModel> userList = new List<UserModel>
		{
			new UserModel() { UserId = 1, FirstName = "Ella", LastName = "Strand"}, 
			new UserModel() { UserId = 2, FirstName = "Lisa", LastName = "Sjöström"}, 
			new UserModel() { UserId = 3, FirstName = "John", LastName = "Andersson"}, 
			new UserModel() { UserId = 4, FirstName = "Sven", LastName = "Olsson"}, 
		};

		public IActionResult Users()
		{
			ViewBag.Count = userList.Count;

			return View(userList);
		}

		public IActionResult AddUser()
		{
			return View(new UserModel());
		}

		[HttpPost]
		public IActionResult AddUser(UserModel user)
		{
			userList.Add(user);
			return RedirectToAction("Users");
		}

		[HttpGet]
		public IActionResult EditUser(int UserId)
		{
			var user = userList.Where(u => u.UserId == UserId).FirstOrDefault();

			return View(user);
		}

		[HttpPost]
		public IActionResult EditUser(UserModel user)
		{
			var existingUser = userList.FirstOrDefault(u => u.UserId == user.UserId);

			if(existingUser != null)
			{
				existingUser.FirstName = user.FirstName;
				existingUser.LastName = user.LastName;
			}

			return RedirectToAction("Users");
		}

		[HttpGet]
		public IActionResult DeleteUser(int UserId)
		{
			var user = userList.FirstOrDefault(u => u.UserId == UserId);

			if(user == null){
				return NotFound();
			}

			return View(user);
		}

		[HttpPost]
		public IActionResult DeleteUserConfirmed(int UserId)
		{
			var user = userList.FirstOrDefault(u => u.UserId == UserId);

			if(user != null)
			{
				userList.Remove(user);
			}

			return RedirectToAction("Users");
		}
	}
}