using Dace23.Demo.UserData;
using System;

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
            var user = _randomUser.Generate();

            var screen = new Screens.Screen(Constants.UserScreenName);

            var userPage = new Pages.Page("USER DETAILS");

            userPage.AddFields(
                new Fields.Label(5, 5, "NAME:"),
                new Fields.TextBox(5, 15, $"{user.Name.Title} {user.Name.Forename} {user.Name.Surname}", width: 41),

                new Fields.Label(7, 5, "EMAIL:"),
                new Fields.TextBox(7, 15, user.Email, width: 41),

                new Fields.Label(9, 5, "PHONE-NO:"),
                new Fields.TextBox(9, 15, user.PhoneNumber.Replace(" ", ""), width: 18),

                new Fields.Label(9, 37, "POSTCODE:"),
                new Fields.TextBox(9, 47, user.Location.Postcode, width: 9),

                new Fields.Label(11, 5, "ADDRESS:"),
                new Fields.TextBox(11, 15, string.Join(Environment.NewLine, user.Location.Address, user.Location.City), width: 41, height: 2),

                new Fields.Label(14, 5, "USERNAME:"),
                new Fields.TextBox(14, 15, user.LoginData.Username, width: 23),

                new Fields.Label(14, 42, "PASSWORD:"),
                new Fields.TextBox(14, 52, user.LoginData.Password, width: 26),

                new Fields.Label(16, 5, "GENDER:"),
                new Fields.TextBox(16, 15, user.Gender, width: 12),

                new Fields.Label(16, 29, "AGE:"),
                new Fields.TextBox(16, 35, user.Age.ToString(), width: 3),

                new Fields.Label(16, 42, "DATE-OF-BIRTH:"),
                new Fields.TextBox(16, 58, user.DateOfBirth.ToString("dd MMMM yyyy (ddd)"), width: 20)
                );

            if (user.Gender == "female")
            {
                userPage.AddFields(
                    new Fields.Label(5, 59,  @"┌─────────────────┐"),
                    new Fields.Label(6, 59,  @"│   ,'s//||\s`.   │"),
                    new Fields.Label(7, 59,  @"│  ///(((||)))\\. │"),
                    new Fields.Label(8, 59,  @"│ (((  ,   ,  ))) │"),
                    new Fields.Label(9, 59,  @"│ _)))   -    |(_ │"),
                    new Fields.Label(10, 59, @"│._//\   -   /\\_.│"),
                    new Fields.Label(11, 59, @"│`-'_/`-._.-'\-`-'│"),
                    new Fields.Label(12, 59, @"└─────────────────┘"));
            }
            else
            {
                userPage.AddFields(
                    new Fields.Label(5, 59,  @"┌────────────────┐"),
                    new Fields.Label(6, 59,  @"|  // /|\ \\\    |"),
                    new Fields.Label(7, 59,  @"│  ;--..--._|}   │"),
                    new Fields.Label(8, 59,  @"│  '--/\--'  )   │"),
                    new Fields.Label(9, 59,  @"│  | '-'  :'|    │"),
                    new Fields.Label(10, 59, @"│  . -==- .-|    │"),
                    new Fields.Label(11, 59, @"│ .-\.__.'   \-._│"),
                    new Fields.Label(12, 59, @"└────────────────┘"));
            }

            screen.AddPage(userPage);

            screen.Start();
        }
    }
}
