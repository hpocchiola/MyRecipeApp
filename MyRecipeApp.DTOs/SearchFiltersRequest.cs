using System.Collections.Generic;

namespace MyRecipeApp.DTOs
{
    public class SearchFiltersRequest
    {
        public string Title { get; set; }
        public ICollection<string> Ingredients { get; set; }
    }
}
