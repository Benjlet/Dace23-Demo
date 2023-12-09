using Dace23Demo.Abstractions;
using Dace23Demo.Models.Users;
using Dace23Demo.Models.Users.Json;

namespace Dace23Demo.Implementation.Services
{
    public class UserClient : IUserClient
    {
        private readonly IHttpClientWrapper _client;

        public UserClient(IHttpClientWrapper client)
        {
            _client = client;
        }

        public async Task<User> Generate()
        {
            UserData usersData = await _client.GetAsync<UserData>($"https://randomuser.me/api/?nat=gb");
            Result userData = usersData?.results?.FirstOrDefault();

            return userData == null ? default : new User()
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