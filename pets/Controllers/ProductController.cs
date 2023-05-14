using Microsoft.AspNetCore.Mvc;
using Services;
using Entites;
using Repository;
using DTO;
using AutoMapper;


namespace pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        public ProductController(IProductService IProductService, IMapper mapper)
        {
            _ProductService = IProductService;
            _mapper = mapper;
        }
        // GET: api/<productController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get([FromQuery] string? name, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
           IEnumerable<Product> products = await _ProductService.getProducts(name, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductDTO> productDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productDto;

        }


    }
}
