using System.Collections.Generic;

namespace MyRecipeApp.DTOs
{
    public class RecipeDto
    {
        public string Title { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}
