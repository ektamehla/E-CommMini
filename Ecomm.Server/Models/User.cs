namespace Ecomm.Server.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public abstract void accessDashboard();

    }

    public class AdminUser : User
    {
        public AdminUser(int id, string username, string password) : base(id, username, password)
        {

        }

        public override void accessDashboard()
        {
            Console.WriteLine("Admin access!");
        }

    }

    public class CustomerUser : User
    {
        public CustomerUser(int id, string username, string password) : base(id, username, password)
        {

        }

        public override void accessDashboard()
        {
            Console.WriteLine("Customer access!");
        }

    }

}
