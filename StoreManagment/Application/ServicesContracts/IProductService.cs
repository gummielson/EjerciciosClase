using Domain.Entities;

namespace Application.ServicesContracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductEntity>> GetAllProducts();
        Task DeleteProduct(int id);
        //Task<ResponseDto> InsertProduct(ProductDto product);
        //Task<IEnumerable<ProductDto>> GetProductsByFilter(string filter);
    }
}
