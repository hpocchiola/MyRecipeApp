using Microsoft.AspNetCore.Mvc;
using MyRecipeApp.DTOs;
using MyRecipeApp.Services.Interfaces;

namespace MyRecipeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        public IActionResult GetAllIngredients()
        {
            return Ok(this.ingredientService.GetAllIngredients());
        }
    }
}
