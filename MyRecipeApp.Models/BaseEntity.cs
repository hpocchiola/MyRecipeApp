using System.ComponentModel.DataAnnotations;

namespace MyRecipeApp.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
