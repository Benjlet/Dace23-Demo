using System.Collections.Generic;
using System.Linq;

namespace Dace23.Demo.CocktailData
{
    public class CocktailFinder
    {
        private readonly HttpClient.HttpClient _httpClient;
        public CocktailFinder()
        {
            _httpClient = new HttpClient.HttpClient();
        }

        public Cocktail[] Find(string criteria, CocktailSearchType searchType)
        {
            string cocktailDataUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

            switch (searchType)
            {
                case CocktailSearchType.Letter:
                    cocktailDataUrl += $"search.php?f={criteria}";
                    break;

                case CocktailSearchType.Random:
                    cocktailDataUrl += $"random.php";
                    break;

                default:
                    cocktailDataUrl += $"search.php?s={criteria}";
                    break;
            }

            var drinkData = _httpClient.Get<DrinkData>(cocktailDataUrl)?.Result;

            return drinkData?.drinks?.Select(drink => new Cocktail()
            {
                Ingredients = GetIngredientsFromDrink(drink)?.ToArray(),
                Alcoholic = drink?.strAlcoholic == "Alcoholic",
                Instructions = drink?.strInstructions,
                Category = drink?.strCategory,
                Glass = drink?.strGlass,
                Name = drink?.strDrink,
                Id = drink?.idDrink
            })?.ToArray();
        }

        private IEnumerable<CocktailIngredient> GetIngredientsFromDrink(Drink drink)
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

        private bool IsPopulated(params string[] text)
        {
            return text?.All(t => !string.IsNullOrWhiteSpace(t)) ?? false;
        }
    }
}
