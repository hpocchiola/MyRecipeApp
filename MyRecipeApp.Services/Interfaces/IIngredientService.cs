using MyRecipeApp.DTOs;
using System.Collections.Generic;

namespace MyRecipeApp.Services.Interfaces
{
    public interface IIngredientService
    {
        ICollection<IngredientDto> GetAllIngredients();
    }
}
