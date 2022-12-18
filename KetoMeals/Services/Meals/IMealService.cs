namespace KetoMeals.Services.Meals;

using System;
using ErrorOr;
using KetoMeals.Models;

public interface IMealService
{
    ErrorOr<Created> CreateMeal(Meal meal);
    ErrorOr<Deleted> DeleteMeal(Guid id);
    ErrorOr<Meal> GetMeal(Guid id);
    ErrorOr<UpdatedMeal> UpdateMeal(Meal meal);
}