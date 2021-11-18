using System.Linq;

namespace Dace23.Demo.UserData
{
    public class RandomUser
    {
        private readonly HttpClient.HttpClient _httpClient;

        public RandomUser()
        {
            _httpClient = new HttpClient.HttpClient();
        }

        public User Generate()
        {
            var usersData = _httpClient.Get<UserData>($"https://randomuser.me/api/?nat=gb")?.Result;
            var userData = usersData?.results?.FirstOrDefault();

            return new User()
            {
                Email = userData.email,
                Age = userData.dob.age,
                Gender = userData.gender,
                PhoneNumber = userData.phone,
                DateOfBirth = userData.dob.date,
                Location = new UserLocation()
                {
                    Address = $"{userData.location.street.number} {userData.location.street.name}",
                    City = userData.location.city,
                    Postcode = userData.location.postcode.ToString()
                },
                LoginData = new UserLogin()
                {
                    Username = userData.login.username,
                    Password = userData.login.password
                },
                Name = new UserName()
                {
                    Forename = userData.name.first,
                    Surname = userData.name.last,
                    Title = userData.name.title
                }
            };
        }
    }
}
