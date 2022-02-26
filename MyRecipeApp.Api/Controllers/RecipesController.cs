using Microsoft.AspNetCore.Mvc;
using MyRecipeApp.DTOs;
using MyRecipeApp.Services.Interfaces;

namespace MyRecipeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            return Ok(this.recipeService.GetAllRecipesWithIngredients());
        }

        [HttpPost("search")]
        public IActionResult SearchRecipes([FromBody] SearchFiltersRequest request)
        {
            return Ok(this.recipeService.SearchRecipes(request));
        }
    }
}
