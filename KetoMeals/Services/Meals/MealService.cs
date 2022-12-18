using ErrorOr;
using KetoMeals.Models;
using KetoMeals.ServiceErrors;

namespace KetoMeals.Services.Meals;

public class MealService : IMealService
{
    private static readonly Dictionary<Guid, Meal> _meals = new();
    public ErrorOr<Created> CreateMeal(Meal meal) 
    {
        _meals.Add(meal.Id, meal);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteMeal(Guid id)
    {
        _meals.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Meal> GetMeal(Guid id)
    {
        if(_meals.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }    
        return Errors.Meal.NotFound;
    }

    public ErrorOr<UpdatedMeal> UpdateMeal(Meal meal)
    {
        var isNewlyCreated = !_meals.ContainsKey(meal.Id);
        _meals[meal.Id] = meal;
        return new UpdatedMeal(isNewlyCreated);
    }
}
