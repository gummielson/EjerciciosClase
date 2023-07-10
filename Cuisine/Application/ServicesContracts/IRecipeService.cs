namespace Application.ServicesContracts
{
    public interface IRecipeService
    {
        Task<decimal> GetRecipePrice(string recipeName);
    }
}
