using Dace23;
using Dace23.Fields;
using Dace23Demo.Abstractions;

namespace Dace23Demo
{
    public class DemoApp
    {
        private readonly Screen _menuScreen;

        public DemoApp(
            ICocktailScreen cocktailScreen,
            IUserScreen userScreen)
        {
            _menuScreen = CreateMenuScreen(cocktailScreen, userScreen);
        }

        public void Run()
        {
            ConsoleUI.Init();
            ConsoleUI.SetWindowTitle(nameof(DemoApp));

            _menuScreen.Start();
        }

        private static Screen CreateMenuScreen(ICocktailScreen cocktailScreen, IUserScreen userScreen)
        {
            Button cocktailNav = new(Pos.On(10, 10), "COCKTAILS", 20);
            Button userNav = new(Pos.Below(cocktailNav, 2), "USER", 20);

            userNav.OnSubmit(() => userScreen.Start());
            cocktailNav.OnSubmit(() => cocktailScreen.Start());

            return new Screen()
                .WithPages(new Page("OPTIONS")
                .WithFields(cocktailNav, userNav));
        }
    }
}
