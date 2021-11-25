using System;
using Dace23.Pages;
using Dace23.Fields;
using Dace23.Screens;
using Dace23.Demo.UserData;

namespace Dace23.Demo.UI
{
    class UserScreen : IScreen
    {
        private readonly RandomUser _randomUser;

        public UserScreen()
        {
            _randomUser = new RandomUser();
        }

        public void Start()
        {
            User user = _randomUser.Generate();
            Screen userScreen = CreateUserScreen(user);

            userScreen.Start();
        }

        private Screen CreateUserScreen(User user)
        {
            var userScreen = new Screen(Constants.UserScreenName);
            var userPage = new Page("USER DETAILS");

            userPage.AddFields(
                new Label(5, 5, "NAME:"),
                new TextBox(5, 15, $"{user.Name.Title} {user.Name.Forename} {user.Name.Surname}", width: 41),

                new Label(7, 5, "EMAIL:"),
                new TextBox(7, 15, user.Email, width: 41),

                new Label(9, 5, "PHONE-NO:"),
                new TextBox(9, 15, user.PhoneNumber.Replace(" ", ""), width: 18),

                new Label(9, 37, "POSTCODE:"),
                new TextBox(9, 47, user.Location.Postcode, width: 9),

                new Label(11, 5, "ADDRESS:"),
                new TextBox(11, 15, string.Join(Environment.NewLine, user.Location.Address, user.Location.City), width: 41, height: 2),

                new Label(14, 5, "USERNAME:"),
                new TextBox(14, 15, user.LoginData.Username, width: 23),

                new Label(14, 42, "PASSWORD:"),
                new TextBox(14, 52, user.LoginData.Password, width: 26),

                new Label(16, 5, "GENDER:"),
                new TextBox(16, 15, user.Gender, width: 12),

                new Label(16, 29, "AGE:"),
                new TextBox(16, 35, user.Age.ToString(), width: 3),

                new Label(16, 42, "DATE-OF-BIRTH:"),
                new TextBox(16, 58, user.DateOfBirth.ToString("dd/MM/yyyy (ddd)"), width: 20));

            if (user.Gender == "female")
            {
                userPage.AddFields(
                    new ScrollBox(5, 59,
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
                    new ScrollBox(5, 59,
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

            userScreen.AddPages(userPage);

            return userScreen;
        }
    }
}
