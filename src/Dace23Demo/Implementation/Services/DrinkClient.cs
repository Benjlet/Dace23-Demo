using Dace23Demo.Abstractions;
using Dace23Demo.Models.Cocktails;
using Dace23Demo.Models.Cocktails.Json;

namespace Dace23Demo.Implementation.Services
{
    public class DrinkClient : IDrinkClient
    {
        private readonly IHttpClientWrapper _client;

        public DrinkClient(IHttpClientWrapper client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Cocktail>> Find(string criteria, CocktailSearchType searchType)
        {
            string cocktailDataUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

            cocktailDataUrl += searchType switch
            {
                CocktailSearchType.Letter => $"search.php?f={criteria}",
                CocktailSearchType.Random => $"random.php",
                _ => $"search.php?s={criteria}",
            };

            DrinkData drinkData = await _client.GetAsync<DrinkData>(cocktailDataUrl);

            return drinkData?.drinks?.Select(d => new Cocktail()
            {
                Ingredients = GetIngredientsFromDrink(d),
                Alcoholic = d?.strAlcoholic == "Alcoholic",
                Instructions = d?.strInstructions,
                Category = d?.strCategory,
                Glass = d?.strGlass,
                Name = d?.strDrink,
                Id = d?.idDrink
            }) ?? Array.Empty<Cocktail>();
        }

        private static IEnumerable<CocktailIngredient> GetIngredientsFromDrink(Drink drink)
        {
            if (drink == null)
            {
                yield break;
            }

            if (IsPopulated(drink.strIngredient1, drink.strMeasure1)) yield return new CocktailIngredient(drink.strIngredient1, drink.strMeasure1);
            if (IsPopulated(drink.strIngredient2, drink.strMeasure2)) yield return new CocktailIngredient(drink.strIngredient2, drink.strMeasure2);
            if (IsPopulated(drink.strIngredient3, drink.strMeasure3)) yield return new CocktailIngredient(drink.strIngredient3, drink.strMeasure3);
            if (IsPopulated(drink.strIngredient4, drink.strMeasure4)) yield return new CocktailIngredient(drink.strIngredient4, drink.strMeasure4);
            if (IsPopulated(drink.strIngredient5, drink.strMeasure5)) yield return new CocktailIngredient(drink.strIngredient5, drink.strMeasure5);
            if (IsPopulated(drink.strIngredient6, drink.strMeasure6)) yield return new CocktailIngredient(drink.strIngredient6, drink.strMeasure6);
            if (IsPopulated(drink.strIngredient7, drink.strMeasure7)) yield return new CocktailIngredient(drink.strIngredient7, drink.strMeasure7);
            if (IsPopulated(drink.strIngredient8, drink.strMeasure8)) yield return new CocktailIngredient(drink.strIngredient8, drink.strMeasure8);
            if (IsPopulated(drink.strIngredient9, drink.strMeasure9)) yield return new CocktailIngredient(drink.strIngredient9, drink.strMeasure9);
            if (IsPopulated(drink.strIngredient10, drink.strMeasure10)) yield return new CocktailIngredient(drink.strIngredient10, drink.strMeasure10);
            if (IsPopulated(drink.strIngredient11, drink.strMeasure11)) yield return new CocktailIngredient(drink.strIngredient11, drink.strMeasure11);
            if (IsPopulated(drink.strIngredient12, drink.strMeasure12)) yield return new CocktailIngredient(drink.strIngredient12, drink.strMeasure12);
            if (IsPopulated(drink.strIngredient13, drink.strMeasure13)) yield return new CocktailIngredient(drink.strIngredient13, drink.strMeasure13);
            if (IsPopulated(drink.strIngredient14, drink.strMeasure14)) yield return new CocktailIngredient(drink.strIngredient14, drink.strMeasure14);
            if (IsPopulated(drink.strIngredient15, drink.strMeasure15)) yield return new CocktailIngredient(drink.strIngredient15, drink.strMeasure15);
        }

        private static bool IsPopulated(params string[] text)
        {
            return text?.All(t => !string.IsNullOrWhiteSpace(t)) ?? false;
        }
    }
}