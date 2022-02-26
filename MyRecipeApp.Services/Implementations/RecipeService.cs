using AutoMapper;
using MyRecipeApp.DTOs;
using MyRecipeApp.Repositories.Interfaces;
using MyRecipeApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRecipeApp.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository recipeRepository;
        private IMapper mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
        }

        public ICollection<RecipeDto> GetAllRecipesWithIngredients()
        {
            return this.mapper.Map<List<RecipeDto>>(this.recipeRepository.GetRecipesWithIngredients().ToList());
        }

        public ICollection<RecipeDto> SearchRecipes(SearchFiltersRequest request)
        {
            return this.mapper.Map<List<RecipeDto>>(this.recipeRepository.SearchRecipes(request));
        }
    }
}
