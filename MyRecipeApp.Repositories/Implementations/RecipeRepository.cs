using Microsoft.EntityFrameworkCore;
using MyRecipeApp.Context;
using MyRecipeApp.DTOs;
using MyRecipeApp.Entities;
using MyRecipeApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipeApp.Repositories.Implementations
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(MyRecipeAppDbContext context) : base(context)
        {
        }

        public ICollection<Recipe> GetRecipesWithIngredients()
        {
            return this.GetAll(x => x.Include(r => r.RecipeIngredient).ThenInclude(ri => ri.Ingredient)).ToList();
        }

        public ICollection<Recipe> SearchRecipes(SearchFiltersRequest request)
        {
            IQueryable<Recipe> query = Context.Set<Recipe>();

            if (!string.IsNullOrEmpty(request.Text))
                query = query.Where(r => EF.Functions.Like(r.Title, $"%{request.Text.Trim()}%"));
            if (request.Ingredients != null && request.Ingredients.Any())
            {
                query = query.Include(r => r.RecipeIngredient).ThenInclude(ri => ri.Ingredient).Where(x => x.RecipeIngredient.Any(y => request.Ingredients.Contains(y.Ingredient.Name)));
            }

            return query.ToList();
        }
    }
}
