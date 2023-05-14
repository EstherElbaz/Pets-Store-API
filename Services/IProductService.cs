using Entites;
using Repository;

namespace Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> getProducts(string? name, int? minPrice, int? maxPrice, int?[] categoryIds);



    }
}