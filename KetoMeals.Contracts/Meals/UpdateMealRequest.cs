namespace KetoMeals.Contracts.Meals;


public record UpdateMealRequest(
    string name,
    string description,
    List<string> ingredients,
    decimal calories,
    decimal net_carbs
) {

}