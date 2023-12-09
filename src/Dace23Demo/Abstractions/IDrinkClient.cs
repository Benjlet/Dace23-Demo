using Dace23Demo.Models.Cocktails;

namespace Dace23Demo.Abstractions
{
    public interface IDrinkClient
    {
        Task<IEnumerable<Cocktail>> Find(string criteria, CocktailSearchType searchType);
    }
}