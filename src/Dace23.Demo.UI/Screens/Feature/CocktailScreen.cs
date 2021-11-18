using Dace23.Demo.CocktailData;
using Dace23.Screens;
using System.Linq;

namespace Dace23.Demo.UI
{
    class CocktailScreen : IScreen
    {
        private readonly Screen _searchScreen;
        private readonly CocktailFinder _cocktailFinder;
        private readonly string _searchBoxName = "tbSearchBox";

        public CocktailScreen()
        {
            _cocktailFinder = new CocktailFinder();
            _searchScreen = CreateSearchScreen();
        }

        public void Start()
        {
            while (true)
            {
                var screenResult = _searchScreen.Start();

                if (screenResult.ExitMode == ScreenExitMode.Exit)
                {
                    return;
                }

                string searchCriteria = screenResult.ActivePage.GetFieldByName(_searchBoxName).Text;

                var cocktails = _cocktailFinder.FindByName(searchCriteria);
                var resultsScreen = CreateResultsScreen(cocktails);

                resultsScreen.Start();
            }
        }

        private Screen CreateResultsScreen(Cocktail[] cocktails)
        {
            var resultsScreen = new Screen(Constants.CocktailScreenName);

            if (cocktails?.Length > 0)
            {
                resultsScreen.AddPages(cocktails.Where(c => c != null)?.Select(c => CreateResultPage(c)));
            }
            else
            {
                resultsScreen.AddPage(new Pages.MessagePage("NO RESULTS", "No results found"));
            }

            return resultsScreen;
        }

        private Pages.Page CreateResultPage(Cocktail cocktail)
        {
            var cocktailPage = new Pages.Page(cocktail.Name ?? "");

            cocktailPage.AddFields(
                new Fields.Label(3, 5, "NAME:"),
                new Fields.TextBox(3, 11, cocktail.Name ?? "", width: 30),

                new Fields.Label(3, 44, "GLASS:"),
                new Fields.TextBox(3, 51, cocktail.Glass ?? "", width: 30),

                new Fields.Label(5, 5, "CATEGORY:"),
                new Fields.TextBox(5, 15, cocktail.Category ?? "", width: 26),

                new Fields.Label(5, 44, "ALCOHOLIC:"),
                new Fields.TextBox(5, 55, cocktail.Alcoholic ? "Y" : "N", width: 2),

                new Fields.Label(5, 61, "ID:"),
                new Fields.TextBox(5, 64, cocktail.Id ?? "", width: 16),

                new Fields.Label(7, 5, "INGREDIENTS:"),
                new Fields.TextBox(9, 5, string.Join("\n", cocktail.Ingredients?.Where(i => i?.Measure != null && i?.Name != null)?
                    .Select(i => $"- {i.Name} ({i.Measure})")), width: 100, height: 4),

                new Fields.Label(14, 5, "INSTRUCTIONS:"),
                new Fields.TextBox(16, 5, cocktail.Instructions ?? "", width: 100, height: 4));

            return cocktailPage;
        }

        private Screen CreateSearchScreen()
        {
            var searchScreen = new Screen(Constants.CocktailScreenName);
            var searchPage = new Pages.Page("COCKTAIL SEARCH");

            searchPage.AddFields(
                new Fields.Label(04, 48, @"   .     .   .  /   "),
                new Fields.Label(05, 48, @" ____._________/_._ "),
                new Fields.Label(06, 48, @" \     .   .  /   / "),
                new Fields.Label(07, 48, @"  \^^^^^^^^^^/^^^/  "),
                new Fields.Label(08, 48, @"   \  o .___/ o /   "),
                new Fields.Label(09, 48, @"    \.  (   ) ./    "),
                new Fields.Label(10, 48, @"     \ o(___) /     "),
                new Fields.Label(11, 48, @"      \  /  o/      "),
                new Fields.Label(12, 48, @"       \. o /       "),
                new Fields.Label(13, 48, @"        \. /        "),
                new Fields.Label(14, 48, @"         \/         "),
                new Fields.Label(15, 48, @"         ||         "),
                new Fields.Label(16, 48, @"         ||         "),
                new Fields.Label(17, 48, @"        /__\        "),

                new Fields.Label(7, 10, text: "NAME:"),
                new Fields.TextBox(8, 10, text: "Margarita", width: 20, name: _searchBoxName));

            searchScreen.AddPage(searchPage);

            return searchScreen;
        }
    }
}
