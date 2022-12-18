namespace KetoMeals.Contracts.Meals;


public record CreateMealRequest(
    string name,
    string description,
    List<string> ingredients,
    decimal calories,
    decimal net_carbs

) {

}