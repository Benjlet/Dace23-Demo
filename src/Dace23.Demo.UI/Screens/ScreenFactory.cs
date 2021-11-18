namespace Dace23.Demo.UI
{
    class ScreenFactory
    {
        public static IScreen Create(string name)
        {
            switch (name)
            {
                case Constants.CocktailScreenName:
                    return new CocktailScreen();

                case Constants.UserScreenName:
                    return new UserScreen();

                default:
                    return null;
            }
        }
    }
}
