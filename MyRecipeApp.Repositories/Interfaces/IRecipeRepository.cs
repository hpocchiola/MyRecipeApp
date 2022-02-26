using MyRecipeApp.DTOs;
using MyRecipeApp.Entities;
using System.Collections.Generic;

namespace MyRecipeApp.Repositories.Interfaces
{
    public interface IRecipeRepository : IBaseRepository<Recipe>
    {
        ICollection<Recipe> GetRecipesWithIngredients();
        ICollection<Recipe> SearchRecipes(SearchFiltersRequest request);
    }
}
