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
            return this.GetAll(x => x.Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)).ToList();
        }

        public ICollection<Recipe> SearchRecipes(SearchFiltersRequest request)
        {
            IQueryable<Recipe> query = Context.Set<Recipe>();

            query = query
                    .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient);

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(r => EF.Functions.Like(r.Title, $"%{request.Title.Trim()}%"));
            }
            if (request.Ingredients != null && request.Ingredients.Any())
            {
                query = query.ToList()
                    .Where(recipe => recipe.RecipeIngredients.Select(ri => ri.Ingredient.Name).Intersect(request.Ingredients).Count() == request.Ingredients.Count)
                    .AsQueryable();
            }
            return query.ToList();
        }
    }
}
