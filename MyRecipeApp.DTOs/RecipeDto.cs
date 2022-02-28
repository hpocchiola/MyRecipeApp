using System.Collections.Generic;

namespace MyRecipeApp.DTOs
{
    public class RecipeDto
    {
        public string Title { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
    }
}
