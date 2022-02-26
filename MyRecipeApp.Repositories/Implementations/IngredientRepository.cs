using Microsoft.EntityFrameworkCore;
using MyRecipeApp.Context;
using MyRecipeApp.Entities;
using MyRecipeApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipeApp.Repositories.Implementations
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(MyRecipeAppDbContext context) : base(context)
        {
        }

    }
}
