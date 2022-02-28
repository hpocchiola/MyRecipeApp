using AutoMapper;
using Microsoft.Extensions.Logging;
using MyRecipeApp.DTOs;
using MyRecipeApp.Repositories.Interfaces;
using MyRecipeApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipeApp.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RecipeService> logger;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper, ILogger<RecipeService> logger)
        {
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public ICollection<RecipeDto> GetAllRecipesWithIngredients()
        {
            try
            {
                return this.mapper.Map<List<RecipeDto>>(this.recipeRepository.GetRecipesWithIngredients().ToList());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public ICollection<RecipeDto> SearchRecipes(SearchFiltersRequest request)
        {
            try
            {
                return this.mapper.Map<List<RecipeDto>>(this.recipeRepository.SearchRecipes(request));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
