namespace Dace23.Demo.CocktailData
{
    public class CocktailIngredient
    {
        public CocktailIngredient(string name, string measure)
        {
            Name = name;
            Measure = measure;
        }
        public string Name { get; }
        public string Measure { get; }
    }
}
