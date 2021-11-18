namespace Dace23.Demo.CocktailData
{
    public class Cocktail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Glass { get; set; }
        public string Instructions { get; set; }
        public CocktailIngredient[] Ingredients { get; set; }
        public bool Alcoholic { get; set; }
    }
}
