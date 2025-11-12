namespace DatabasLab1.Models
{
	public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public User()
        {
            Firstname = "Unknown";
            Lastname = "User";
        }

        public User(int userId, string firstname, string lastname)
        {
            UserId = userId;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}