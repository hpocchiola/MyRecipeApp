using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyRecipeApp.Entities
{
    public class Recipe : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public bool ContainsAllIngredients(ICollection<string> ingredients)
        {
            return this.RecipeIngredients.Select(ri => ri.Ingredient.Name).Intersect(ingredients).Count() == ingredients.Count;
        }
    }
}
