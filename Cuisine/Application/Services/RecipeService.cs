using Application.ServicesContracts;
using Crosscuting.CustomExceptions;
using Data.Repositories;
using Domain.Entities;
using static Domain.Entities.RecipeData;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository _repository;

        public RecipeService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> GetRecipePrice(string recipeName)
        {
            IEnumerable<RecipeData> recipes = await GetRecipes();
            RecipeData? recipe = recipes.FirstOrDefault(x => x.Name == recipeName);

            if (recipe is not null)
            {
                decimal price = await CalculateRecipePrice(recipe);

                return price;
            }
            else
            {
                throw new NotRecipeFoundException();
            }
        }

        #region private methods

        private async Task<decimal> CalculateRecipePrice(RecipeData recipe)
        {
            decimal price = 0;

            price += recipe.MinutesPerCooking * (await GetPrices()).First().PricePerMinute;
            var foods = await GetFoods();

            foreach (var ingredient in recipe.Ingredients)
            {
                var ingredientPrice = foods.FirstOrDefault(x => x.Name == ingredient.Key);

                if (ingredientPrice is not null)
                {
                    price += ingredient.Value * ingredientPrice.Price;
                }
            }

            return price;
        }

        private async Task<IEnumerable<Food>> GetFoods()
        {
            return await _repository.GetAll<Food>("Food");
        }

        private async Task<IEnumerable<Price>> GetPrices()
        {
            return await _repository.GetAll<Price>("Price");
        }

        private async Task<IEnumerable<RecipeData>> GetRecipes()
        {
            return await _repository.GetAll<RecipeData>("Recipes");
        }
        #endregion
    }
}
