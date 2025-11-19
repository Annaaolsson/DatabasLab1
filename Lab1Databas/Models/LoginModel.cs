using System.ComponentModel.DataAnnotations;

namespace DatabasLab1.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Du måste ange ett användarnamn")]
		public string UserName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Du måste ange ett lösenord")]
		public string Password { get; set; } = string.Empty;
	}
}