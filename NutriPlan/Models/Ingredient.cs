namespace NutriPlan.Models
{
    public enum IngredientType
    {
        Dairy,
        Vegetable,
        Fruit,
        Meat,
        Fish,
        Condiment,
        Seafood,
        Grains,
        Other
    }
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public int Calories { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    }
}
