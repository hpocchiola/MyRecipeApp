using MyRecipeApp.Context;
using MyRecipeApp.Entities;
using MyRecipeApp.Repositories.Implementations;

namespace MyRecipeApp.Repositories.Interfaces
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(MyRecipeAppDbContext context) : base(context)
        {
        }
    }
}
