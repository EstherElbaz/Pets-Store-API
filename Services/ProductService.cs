using Entites;
using Repository;



namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        public ProductService(IProductRepository IProductRepository)
        {
            _ProductRepository = IProductRepository;
        }


        public async Task<IEnumerable<Product>> getProducts(string? name, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _ProductRepository.getProducts(name, minPrice, maxPrice, categoryIds);

        }




    }
}