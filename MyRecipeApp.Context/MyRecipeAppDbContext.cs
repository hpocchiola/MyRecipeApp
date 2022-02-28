using Microsoft.EntityFrameworkCore;
using MyRecipeApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipeApp.Context
{
    public class MyRecipeAppDbContext : DbContext
    {
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public MyRecipeAppDbContext(DbContextOptions<MyRecipeAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });
        }

        public void SeedDatabase()
        {
            Ingredient peanutButter = new Ingredient() { Name = "Peanut Butter" };
            Ingredient jelly = new Ingredient() { Name = "Jelly" };
            Ingredient bread = new Ingredient() { Name = "Bread" };
            Ingredient chocolate = new Ingredient() { Name = "Chocolate" };
            Ingredient sugar = new Ingredient() { Name = "Sugar" };
            Ingredient cheese = new Ingredient() { Name = "Cheese" };
            Ingredient pizzaDough = new Ingredient() { Name = "Pizza Dough" };
            Ingredient tomatoSauce = new Ingredient() { Name = "Tomato Sauce" };
            Ingredient pineapple = new Ingredient() { Name = "Pineapple" };
            Ingredient bacon = new Ingredient() { Name = "Bacon" };
            Ingredient milk = new Ingredient() { Name = "Milk" };

            Recipe pbj = new Recipe() { Title = "Peanut Butter and Jelly Sandwich" };
            Recipe buckeyes = new Recipe() { Title = "Buckeyes" };
            Recipe hawaiianPizza = new Recipe() { Title = "Hawaiian Pizza" };
            Recipe hotChocolate = new Recipe() { Title = "Hot Chocolate" };
            Recipe gcs = new Recipe() { Title = "Grilled Cheese Sandwich" };

            RecipeIngredient pbjButter = new RecipeIngredient() { Recipe = pbj, Ingredient = peanutButter };
            RecipeIngredient pbjJelly = new RecipeIngredient() { Recipe = pbj, Ingredient = jelly };
            RecipeIngredient pbjBread = new RecipeIngredient() { Recipe = pbj, Ingredient = bread };
            RecipeIngredient buckeyesChocolate = new RecipeIngredient() { Recipe = buckeyes, Ingredient = chocolate };
            RecipeIngredient buckeyesButter = new RecipeIngredient() { Recipe = buckeyes, Ingredient = peanutButter };
            RecipeIngredient buckeyesSugar = new RecipeIngredient() { Recipe = buckeyes, Ingredient = sugar };
            RecipeIngredient pizzaCheese = new RecipeIngredient() { Recipe = hawaiianPizza, Ingredient = cheese };
            RecipeIngredient pizzaPizzaDough = new RecipeIngredient() { Recipe = hawaiianPizza, Ingredient = pizzaDough };
            RecipeIngredient pizzaSauce = new RecipeIngredient() { Recipe = hawaiianPizza, Ingredient = tomatoSauce };
            RecipeIngredient pizzaPineapple = new RecipeIngredient() { Recipe = hawaiianPizza, Ingredient = pineapple };
            RecipeIngredient pizzaBacon = new RecipeIngredient() { Recipe = hawaiianPizza, Ingredient = bacon };
            RecipeIngredient hotChocolateMilk = new RecipeIngredient() { Recipe = hotChocolate, Ingredient = milk };
            RecipeIngredient hotChocolateChocolate = new RecipeIngredient() { Recipe = hotChocolate, Ingredient = chocolate };
            RecipeIngredient hotChocolateSugar = new RecipeIngredient() { Recipe = hotChocolate, Ingredient = sugar };
            RecipeIngredient sandwichBread = new RecipeIngredient() { Recipe = gcs, Ingredient = bread };
            RecipeIngredient sandwichCheese = new RecipeIngredient() { Recipe = gcs, Ingredient = cheese };

            pbj.RecipeIngredients = new List<RecipeIngredient>() { pbjButter, pbjJelly, pbjBread };
            buckeyes.RecipeIngredients = new List<RecipeIngredient>() { buckeyesChocolate, buckeyesButter, buckeyesSugar };
            hawaiianPizza.RecipeIngredients = new List<RecipeIngredient>() { pizzaCheese, pizzaPizzaDough, pizzaSauce, pizzaPineapple, pizzaBacon };
            hotChocolate.RecipeIngredients = new List<RecipeIngredient>() { hotChocolateMilk, hotChocolateChocolate, hotChocolateSugar };
            gcs.RecipeIngredients = new List<RecipeIngredient>() { sandwichBread, sandwichCheese };

            if (!Ingredients.Any())
            {
                Ingredients.AddRange(new List<Ingredient>() { peanutButter, jelly, bread, chocolate, sugar, cheese, pizzaDough, tomatoSauce, pineapple, bacon, milk });
            }
            if (!Recipes.Any())
            {
                Recipes.AddRange(new List<Recipe>() { pbj, buckeyes, hawaiianPizza, hotChocolate, gcs });
            }
            if (!RecipeIngredients.Any())
            {
                RecipeIngredients.AddRange(new List<RecipeIngredient>() { pbjButter, pbjJelly, pbjBread, buckeyesChocolate, buckeyesButter, buckeyesSugar, pizzaCheese, pizzaPizzaDough, pizzaSauce, pizzaPineapple, pizzaBacon, hotChocolateMilk, hotChocolateChocolate, hotChocolateSugar, sandwichBread, sandwichCheese });
            }

            SaveChanges();
        }
    }
}
