using MyRecipeApp.DTOs;
using System.Collections.Generic;

namespace MyRecipeApp.Services.Interfaces
{
    public interface IRecipeService
    {
        ICollection<RecipeDto> GetAllRecipesWithIngredients();
        ICollection<RecipeDto> SearchRecipes(SearchFiltersRequest request);
    }
}
