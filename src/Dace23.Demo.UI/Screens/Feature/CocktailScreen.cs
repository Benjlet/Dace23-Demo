using Dace23.Demo.CocktailData;
using Dace23.Screens;
using Dace23.Pages;
using Dace23.Fields;
using System.Linq;
using System;

namespace Dace23.Demo.UI
{
    class CocktailScreen : IScreen
    {
        private readonly Screen _searchScreen;
        private readonly CocktailFinder _cocktailFinder;

        private readonly string _criteriaFieldName = "tbCriteria";
        private readonly string _searchTypeFieldName = "dbSearchType";

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

                string searchCriteria = screenResult.ActivePage.Fields[_criteriaFieldName].Text;
                Enum.TryParse(screenResult.ActivePage.Fields[_searchTypeFieldName].Text, out CocktailSearchType cocktailSearchType);

                var cocktails = _cocktailFinder.Find(searchCriteria, cocktailSearchType);

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
                resultsScreen.AddPages(new MessagePage("NO RESULTS", "No results found"));
            }

            return resultsScreen;
        }

        private Page CreateResultPage(Cocktail cocktail)
        {
            return new Page(cocktail.Name ?? "")
            {
                Fields = new FieldCollection()
                {
                    new Label(3, 5, "NAME:"),
                    new TextBox(3, 11, cocktail.Name ?? "", width: 30),

                    new Label(3, 44, "GLASS:"),
                    new TextBox(3, 51, cocktail.Glass ?? "", width: 30),

                    new Label(5, 5, "CATEGORY:"),
                    new TextBox(5, 15, cocktail.Category ?? "", width: 26),

                    new Label(5, 44, "ALCOHOLIC:"),
                    new TextBox(5, 55, cocktail.Alcoholic ? "Y" : "N", width: 2),

                    new Label(5, 61, "ID:"),
                    new TextBox(5, 64, cocktail.Id ?? "", width: 16),

                    new Label(7, 5, "INGREDIENTS:"),
                    new TextBox(9, 5, string.Join("\n", cocktail.Ingredients?.Where(i => i?.Measure != null && i?.Name != null)?
                        .Select(i => $"- {i.Name} ({i.Measure})")), width: 100, height: 4),

                    new Label(14, 5, "INSTRUCTIONS:"),
                    new TextBox(16, 5, cocktail.Instructions ?? "", width: 100, height: 4)
                }
            };
        }

        private Screen CreateSearchScreen()
        {
            var searchScreen = new Screen(Constants.CocktailScreenName);
            var searchPage = new Page("COCKTAIL SEARCH");

            searchPage.AddFields(
                new Label(04, 48, @"   .     .   .  /   "),
                new Label(05, 48, @" ____._________/_._ "),
                new Label(06, 48, @" \     .   .  /   / "),
                new Label(07, 48, @"  \^^^^^^^^^^/^^^/  "),
                new Label(08, 48, @"   \  o .___/ o /   "),
                new Label(09, 48, @"    \.  (   ) ./    "),
                new Label(10, 48, @"     \ o(___) /     "),
                new Label(11, 48, @"      \  /  o/      "),
                new Label(12, 48, @"       \. o /       "),
                new Label(13, 48, @"        \. /        "),
                new Label(14, 48, @"         \/         "),
                new Label(15, 48, @"         ||         "),
                new Label(16, 48, @"         ||         "),
                new Label(17, 48, @"        /__\        "),

                new Label(10, 10, text: "CRITERIA:"),
                new TextBox(11, 10, text: "Margarita", width: 20, name: _criteriaFieldName),
                
                new Label(7, 10, text: "SEARCH TYPE:"),
                new DropDownBox(8, 10, Enum.GetNames(typeof(CocktailSearchType)), 10, _searchTypeFieldName));

            searchScreen.AddPages(searchPage);

            return searchScreen;
        }
    }
}
