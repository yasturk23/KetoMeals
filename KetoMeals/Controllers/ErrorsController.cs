using Microsoft.AspNetCore.Mvc;

namespace KetoMeals.Controllers;

public class ErrorsController : ControllerBase 
{

[Route("/error")]
public IActionResult Error()
{
    return Problem();
}

}