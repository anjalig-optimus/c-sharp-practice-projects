using WebAPIUsecase.Core.Entities;

namespace WebAPIUsecase.Infrastructure.Data
{
    public interface InMemoryProductRepository:IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public Task<List<Product>> GetProductsAsync() => Task.FromResult(_products);

        public Task<Product> GetProductByIdAsync(int productId) =>
            Task.FromResult(_products.FirstOrDefault(p => p.Id == productId));

        public Task AddProductAsync(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return Task.CompletedTask;
        }
    }
}
