using Domain.Entities;

namespace Domain.RepositoryContracts
{
    public interface IProductRepository
    {
        //Task<IEnumerable<ProductEntity>> GetAllProducts();
        //Task InsertProduct(ProductEntity product);
        Task SaveDataInFile();
    }
}
