namespace KetoMeals.Contracts.Meals;


public record MealResponse(
    Guid id,
    string name,
    string description,
    List<string> ingredients,
    decimal calories,
    decimal net_carbs

) {

}