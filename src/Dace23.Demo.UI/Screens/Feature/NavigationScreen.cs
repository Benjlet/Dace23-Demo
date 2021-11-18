using Dace23.Screens;
using System.Collections.Generic;

namespace Dace23.Demo.UI
{
    class NavigationScreen : IScreen
    {
        private readonly Screen _exitScreen;
        private readonly Screen _navigationScreen;

        private readonly CocktailScreen _cocktailSearch;
        private readonly UserScreen _userGenerator;

        public NavigationScreen()
        {
            Dace23.Init();
            Dace23.SetWindowTitle("Demo Screens");

            _navigationScreen = CreateNavigationScreen();
            _exitScreen = CreateExitScreen();

            _cocktailSearch = new CocktailScreen();
            _userGenerator = new UserScreen();
        }

        public void Start()
        {
            while (true)
            {
                var screenResult = _navigationScreen.Start();

                if (screenResult.ExitMode == ScreenExitMode.Exit)
                {
                    break;
                }

                var selectedScreen = ScreenFactory.Create(screenResult.ActiveField.Text);
                selectedScreen.Start();
            }

            _exitScreen.Start();
        }

        private Screen CreateNavigationScreen()
        {
            return new SelectionScreen("MAIN MENU", 
                new List<string>()
                {
                    Constants.CocktailScreenName,
                    Constants.UserScreenName
                });
        }

        private Screen CreateExitScreen()
        {
            return new MessageScreen("EXIT", "**** USER DISCONNECTED ****");
        }
    }
}
