using System.Linq;
using AutoMapper;
using MyRecipeApp.DTOs;
using MyRecipeApp.Entities;

namespace MyRecipeApp.Repositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.Title, src => src.MapFrom(u => u.Title))
                .ForMember(dest => dest.Ingredients, src => src.MapFrom(x => x.RecipeIngredient.Select(y => new IngredientDto() { Name = y.Ingredient.Name }).ToList()));

            CreateMap<Ingredient, IngredientDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(u => u.Name));
        }
    }
}