using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab1Databas.Models;
using DatabasLab1.Models;

namespace Lab1Databas.Controllers;

public class HomeController : Controller
{
    static List<LoginModel> LoginList = new List<LoginModel>();

	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Login(LoginModel login)
	{
		if(login.UserName == "Anna" && login.Password == "Anna")
		{
			return RedirectToAction("Index");
		}

		return View("Login", login);
	}
	
	private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
