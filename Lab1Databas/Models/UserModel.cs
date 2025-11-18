namespace DatabasLab1.Models
{
	public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserModel()
        {
            FirstName = "Unknown FirstName";
            LastName = "Unknown LastName";
        }

        public UserModel(int userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}