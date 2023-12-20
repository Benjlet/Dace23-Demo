using Dace23;
using Dace23.Fields;
using Dace23Demo.Abstractions;
using Dace23Demo.Models.Users;

namespace Dace23Demo.Implementation.Screens
{
    public class UserScreen : IUserScreen
    {
        private readonly IUserClient _userClient;

        public UserScreen(IUserClient userClient)
        {
            _userClient = userClient;
        }

        public void Start()
        {
            User user = _userClient.Generate().GetAwaiter().GetResult();
            Screen userScreen = CreateUserScreen(user);

            userScreen.Start();
        }

        private static Screen CreateUserScreen(User user)
        {
            var userPage = new Page("USER DETAILS").WithFields(
                new Label(Pos.On(5, 5), "NAME:"),
                new TextBox(Pos.On(5, 15), $"{user.Name.Title} {user.Name.Forename} {user.Name.Surname}", width: 41),

                new Label(Pos.On(7, 5), "EMAIL:"),
                new TextBox(Pos.On(7, 15), user.Email, width: 41),

                new Label(Pos.On(9, 5), "PHONE-NO:"),
                new TextBox(Pos.On(9, 15), user.PhoneNumber.Replace(" ", ""), width: 18),

                new Label(Pos.On(9, 37), "POSTCODE:"),
                new TextBox(Pos.On(9, 47), user.Location.Postcode, width: 9),

                new Label(Pos.On(11, 5), "ADDRESS:"),
                new TextBox(Pos.On(11, 15), string.Join(Environment.NewLine, user.Location.Address, user.Location.City), width: 41, height: 2),

                new Label(Pos.On(14, 5), "USERNAME:"),
                new TextBox(Pos.On(14, 15), user.LoginData.Username, width: 23),

                new Label(Pos.On(14, 42), "PASSWORD:"),
                new TextBox(Pos.On(14, 52), user.LoginData.Password, width: 26),

                new Label(Pos.On(16, 5), "GENDER:"),
                new TextBox(Pos.On(16, 15), user.Gender, width: 12),

                new Label(Pos.On(16, 29), "AGE:"),
                new TextBox(Pos.On(16, 35), user.Age.ToString(), width: 3),

                new Label(Pos.On(16, 42), "DATE-OF-BIRTH:"),
                new TextBox(Pos.On(16, 58), user.DateOfBirth.ToString("dd/MM/yyyy (ddd)"), width: 20));

            if (user.Gender == "female")
            {
                userPage.AddFields(
                    new Label(Pos.On(5, 59),
                        @"┌─────────────────┐" +
                        @"│   ,'s//||\s`.   │" +
                        @"│  ///(((||)))\\. │" +
                        @"│ (((  ,   ,  ))) │" +
                        @"│ _)))   -    |(_ │" +
                        @"│._//\   -   /\\_.│" +
                        @"│`-'_/`-._.-'\-`-'│" +
                        @"└─────────────────┘",
                        height: 8, width: 19));
            }
            else
            {
                userPage.AddFields(
                    new Label(Pos.On(5, 59),
                        @"┌─────────────────┐" +
                        @"|  // /|\ \\\     |" +
                        @"│  ;--..--._|}    │" +
                        @"│  '--/\--'  )    │" +
                        @"│  | '-'  :'|     │" +
                        @"│  . -==- .-|     │" +
                        @"│ .-\.__.'   \-._ │" +
                        @"└─────────────────┘",
                        height: 8, width: 19));
            }

            return new Screen().WithPages(userPage);
        }
    }
}