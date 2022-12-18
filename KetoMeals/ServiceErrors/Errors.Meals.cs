using ErrorOr;

namespace KetoMeals.ServiceErrors;

public static class Errors
{
    
    
    public static class Meal
    {
        public static Error InvalidName => Error.Validation(
            code: "Meal.InvalidName",
            description: $"Meal name must be at least {Models.Meal.MinNameLength} and at most {Models.Meal.MaxNameLength} characters long"); 

          public static Error InvalidDescription => Error.Validation(
            code: "Meal.InvalidDescription",
            description: $"Meal description must be at least {Models.Meal.MinDescriptionLength} and at most {Models.Meal.MaxDescriptionLength} characters long"); 

            public static Error InvalidIngredients=> Error.Validation(
            code: "Meal.InvalidIngredients",
            description: $"Meals must have at least {Models.Meal.MinNbIngredients} ingredients"); 

            public static Error InvalidCalories => Error.Validation(
            code: "Meal.InvalidCalories",
            description: $"Meal calories must be at least {Models.Meal.MinCalories} calories");

            public static Error InvalidNetCarbs => Error.Validation(
            code: "Meal.InvalidNetCarbs",
            description: $"Meal net carbs must be at least {Models.Meal.MinNetCarbs} net carbs");

        
        public static Error NotFound => Error.NotFound(
            code: "Meal.NotFound",
            description: "Meal not found"); 
        
        
    }
}