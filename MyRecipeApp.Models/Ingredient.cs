using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRecipeApp.Entities
{
    public class Ingredient : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
