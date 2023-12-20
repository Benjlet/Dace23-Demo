using Dace23;
using Dace23.Fields;
using Dace23.Pages;
using Dace23Demo.Abstractions;
using Dace23Demo.Models.Cocktails;

namespace Dace23Demo.Implementation.Screens
{
    public class CocktailScreen : ICocktailScreen
    {
        private readonly IDrinkClient _drinkClient;
        private readonly Screen _searchScreen;

        public CocktailScreen(IDrinkClient drinkClient)
        {
            _drinkClient = drinkClient;
            _searchScreen = CreateSearchScreen();
        }

        public void Start()
        {
            _searchScreen.Start();
        }

        private Screen CreateSearchScreen()
        {
            Page searchPage = new("COCKTAIL SEARCH");

            DropDownBox dropDown = new(Pos.On(8, 10), Enum.GetNames(typeof(CocktailSearchType)), 20);
            TextBox criteria = new(Pos.On(11, 10), "Margarita", 20);

            searchPage.AddFields(
                new Label(Pos.On(04, 48), @"   .     .   .  /   "),
                new Label(Pos.On(05, 48), @" ____._________/_._ "),
                new Label(Pos.On(06, 48), @" \     .   .  /   / "),
                new Label(Pos.On(07, 48), @"  \^^^^^^^^^^/^^^/  "),
                new Label(Pos.On(08, 48), @"   \  o .___/ o /   "),
                new Label(Pos.On(09, 48), @"    \.  (   ) ./    "),
                new Label(Pos.On(10, 48), @"     \ o(___) /     "),
                new Label(Pos.On(11, 48), @"      \  /  o/      "),
                new Label(Pos.On(12, 48), @"       \. o /       "),
                new Label(Pos.On(13, 48), @"        \. /        "),
                new Label(Pos.On(14, 48), @"         \/         "),
                new Label(Pos.On(15, 48), @"         ||         "),
                new Label(Pos.On(16, 48), @"         ||         "),
                new Label(Pos.On(17, 48), @"        /__\        "),

                new Label(Pos.On(10, 10), "CRITERIA:"),
                new Label(Pos.On(7, 10), "SEARCH TYPE:")
            );

            Button searchButton = new(Pos.On(13, 10), " SEARCH -> ", 20);

            searchButton.OnSubmit(() =>
            {
                IEnumerable<Cocktail> cocktails = _drinkClient.Find(criteria.Text, Enum.Parse<CocktailSearchType>(dropDown.Text)).GetAwaiter().GetResult();
                Screen resultsScreen = CreateResultsScreen(cocktails);

                resultsScreen.Start();
            });

            searchPage.AddFields(dropDown, criteria, searchButton);

            return new Screen().WithPages(searchPage);
        }

        private static Screen CreateResultsScreen(IEnumerable<Cocktail> cocktails)
        {
            Screen resultsScreen = new();

            if (cocktails != null && cocktails.Any())
            {
                resultsScreen.AddPages(cocktails.Select(c => CreateResultPage(c)));
            }
            else
            {
                resultsScreen.AddPages(new MessagePage("NO RESULTS", "No results found"));
            }

            return resultsScreen;
        }

        private static Page CreateResultPage(Cocktail cocktail) => new Page(cocktail.Name).WithFields(
            new Label(Pos.On(3, 5), "NAME:"),
            new TextBox(Pos.On(3, 11), cocktail.Name ?? "", width: 30),
            new Label(Pos.On(3, 44), "GLASS:"),
            new TextBox(Pos.On(3, 51), cocktail.Glass ?? "", width: 25),
            new Label(Pos.On(5, 5), "CATEGORY:"),
            new TextBox(Pos.On(5, 15), cocktail.Category ?? "", width: 26),
            new Label(Pos.On(5, 44), "ALCOHOLIC:"),
            new TextBox(Pos.On(5, 55), cocktail.Alcoholic ? "Y" : "N", width: 2),
            new Label(Pos.On(5, 61), "ID:"),
            new TextBox(Pos.On(5, 64), cocktail.Id ?? "", width: 9),
            new Label(Pos.On(7, 5), "INGREDIENTS:"),
            new TextBox(Pos.On(9, 5), string.Join("\n", cocktail.Ingredients.Select(i => $"- {i.Name} ({i.Measure})")), width: 60, height: 4),
            new Label(Pos.On(14, 5), "INSTRUCTIONS:"),
            new TextBox(Pos.On(16, 5), cocktail.Instructions ?? "", width: 60, height: 4));
    }
}