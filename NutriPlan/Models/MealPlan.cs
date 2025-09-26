namespace NutriPlan.Models
{
    public enum DaysOfWeek
    {
        Monday, 
        Tuesday, 
        Wednesday,
        Thursday, 
        Friday,
        Saturday,
        Sunday
    }

    public enum MealType
    {
        Breakfast, 
        Lunch, 
        Dinner, 
        Snack
    }
    public class MealPlan
    {
        public int MealPlanId { get; set; }
        public string MealPlanName { get; set; }

        public DaysOfWeek Day {  get; set; }


        public MealType MealType { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
