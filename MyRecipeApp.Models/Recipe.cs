using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRecipeApp.Entities
{
    public class Recipe : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
