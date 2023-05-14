using Microsoft.AspNetCore.Mvc;
using Services;
using Entites;
using AutoMapper;
using DTO;


namespace pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService ICategoryService, IMapper mapper)
        {
            _categoryService = ICategoryService;
            _mapper = mapper;

        }
        // GET: api/<categoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {

            IEnumerable<Category> categories = await _categoryService.getCategory();
            IEnumerable<CategoryDTO> categoryDto = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return Ok(categoryDto);
        }

    }
}
