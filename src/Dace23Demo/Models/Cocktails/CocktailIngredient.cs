namespace Dace23Demo.Models.Cocktails
{
    public class CocktailIngredient
    {
        public string Name { get; }
        public string Measure { get; }
        public CocktailIngredient(string name, string measure)
        {
            Name = name;
            Measure = measure;
        }
    }
}