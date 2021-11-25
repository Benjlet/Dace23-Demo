using System;

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

                case Constants.ExamplesScreenName:
                    return new ExamplesScreen();

                default:
                    throw new NotSupportedException($"Screen '{name}' not configured.");
            }
        }
    }
}
