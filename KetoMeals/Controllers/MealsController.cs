using Microsoft.AspNetCore.Mvc;
using KetoMeals.Models;
using KetoMeals.Contracts.Meals;
using KetoMeals.Services.Meals;
using ErrorOr;

namespace KetoMeals.Controllers;



public class MealsController : ApiController
{
    //needed for dependancy injection
    private readonly IMealService _mealService;

    public MealsController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpPost]

    public IActionResult CreateMeal(CreateMealRequest request)
    {
        ErrorOr<Meal> requestToMealResult = Meal.From(request);

        if(requestToMealResult.IsError)
        {
            return Problem(requestToMealResult.Errors);
        }

        var meal = requestToMealResult.Value;
        ErrorOr<Created> createMealResult = _mealService.CreateMeal(meal);

        return createMealResult.Match(
            created => CreatedAtGetMeal(meal),
            errors => Problem(errors)
        );
    }

   

    [HttpGet("{id:guid}")]

    public IActionResult GetMeal(Guid id)
    {
        ErrorOr<Meal> getMealResult = _mealService.GetMeal(id);

        return getMealResult.Match(
            meal => Ok(MapMealResponse(meal)),
            errors => Problem(errors)
        );
        
    }

 

    [HttpPut("{id:guid}")]

    public IActionResult UpdateMeal(Guid id, UpdateMealRequest request)

    {

        ErrorOr<Meal> requestToMealResult = Meal.From(id, request);

         if(requestToMealResult.IsError)
        {
            return Problem(requestToMealResult.Errors);
        }

        var meal = requestToMealResult.Value;
        ErrorOr<UpdatedMeal> updateResult = _mealService.UpdateMeal(meal);

        return updateResult.Match(
            updated=> updated.IsNewlyCreated ? CreatedAtGetMeal(meal) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]

    public IActionResult DeleteMeal(Guid id)
    {
        ErrorOr<Deleted> deleteResult =  _mealService.DeleteMeal(id);

        return deleteResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

       private static MealResponse MapMealResponse(Meal meal)
    {
        return new MealResponse(
            meal.Id,
            meal.Name,
            meal.Description,
            meal.Ingredients,
            meal.Calories,
            meal.Net_Carbs
        );
    }

     private CreatedAtActionResult CreatedAtGetMeal(Meal meal)
    {
        return CreatedAtAction(
            nameof(GetMeal),
            routeValues: new { id = meal.Id },
            value: MapMealResponse(meal));
    }
}