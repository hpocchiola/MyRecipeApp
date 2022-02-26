using System.ComponentModel.DataAnnotations;

namespace MyRecipeApp.Entities
{
    public class RecipeIngredient
    {
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int IngredientId { get; set; }

        public Recipe Recipe { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
