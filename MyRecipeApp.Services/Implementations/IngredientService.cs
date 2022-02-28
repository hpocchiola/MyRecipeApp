using AutoMapper;
using MyRecipeApp.DTOs;
using MyRecipeApp.Repositories.Implementations;
using MyRecipeApp.Services.Interfaces;
using System.Collections.Generic;

namespace MyRecipeApp.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMapper mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            this.ingredientRepository = ingredientRepository;
            this.mapper = mapper;
        }

        public ICollection<IngredientDto> GetAllIngredients()
        {
            return this.mapper.Map<List<IngredientDto>>(this.ingredientRepository.GetAll());
        }
    }
}
