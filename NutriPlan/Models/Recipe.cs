namespace NutriPlan.Models
{

    public enum RecipeType
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack,
        Any
    }

    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public RecipeType Type { get; set; }
        public bool isFavorite { get; set; }
        public int Calories { get; set; }


        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    }
}
