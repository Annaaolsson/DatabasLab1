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
			return View(userList);
		}
	}
}