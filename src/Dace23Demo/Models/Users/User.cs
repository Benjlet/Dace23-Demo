namespace Dace23Demo.Models.Users
{
    public class User
    {
        public UserName Name { get; set; }
        public UserLogin LoginData { get; set; }
        public UserLocation Location { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
