using WebAPIUsecase.Core.Entities;

namespace WebAPIUsecase.Infrastructure.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task AddProductAsync(Product product);
    }
}
