
using ErrorOr;
using KetoMeals.Contracts.Meals;
using KetoMeals.ServiceErrors;

namespace KetoMeals.Models;

public class Meal
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public const int MinDescriptionLength = 20;
    public const int MaxDescriptionLength = 100;

    public const int MinNbIngredients = 2;

    public const int MinCalories = 0;
    public const int MinNetCarbs = 0;

    public Guid Id {get;}
    public String Name {get;}
    public String Description {get;}

    public List<String> Ingredients {get;}

    public Decimal Calories {get;}
    public Decimal Net_Carbs {get;}

    private Meal (
        Guid aId,
        String aName,
        String aDescription,
        List<String> aIngredients,
        Decimal aCalories,
        Decimal aNet_Carbs) 
    {
        Id = aId;
        Name = aName;
        Description = aDescription;
        Ingredients = aIngredients;
        Calories = aCalories;
        Net_Carbs = aNet_Carbs;
    }

    public static ErrorOr<Meal> Create(

        String name,
        String description,

        List<String> ingredients,

        Decimal calories,
        Decimal net_carbs,
        Guid? id = null) 
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength || name.Length > MaxNameLength)
        {
            errors.Add(Errors.Meal.InvalidName);
        }

        if (description.Length is < MinDescriptionLength || description.Length > MaxDescriptionLength)
        {
            errors.Add(Errors.Meal.InvalidDescription);
        }

        if (ingredients.Count is < MinNbIngredients)
        {
            errors.Add(Errors.Meal.InvalidIngredients);
        }

        if (calories is < MinCalories)
        {
            errors.Add(Errors.Meal.InvalidCalories);
        }

         if (net_carbs is < MinNetCarbs)
        {
            errors.Add(Errors.Meal.InvalidNetCarbs);
        }

        if(errors.Count > 0)
        {
            return errors;
        }
       
        return new Meal(
            id ?? Guid.NewGuid(),
            name,
            description,
            ingredients,
            calories,
            net_carbs);
    }

    public static ErrorOr<Meal> From(CreateMealRequest request)
    {
        return Create(
            request.name,
            request.description,
            request.ingredients,
            request.calories,
            request.net_carbs

        );
    }

    public static ErrorOr<Meal> From(Guid id, UpdateMealRequest request)
    {
        return Create(
            request.name,
            request.description,
            request.ingredients,
            request.calories,
            request.net_carbs
        );
    }


}