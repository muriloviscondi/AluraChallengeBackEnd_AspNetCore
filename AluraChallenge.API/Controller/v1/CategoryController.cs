using AluraChallenge.API.Controller.Base;
using AluraChallenge.API.Models;
using AluraChallenge.Domain.Arguments.Category;
using AluraChallenge.Domain.Interfaces.Services;
using AluraChallenge.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AluraChallenge.API.Controller.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly IServiceCategory _serviceCategory;
        private readonly IServiceVideo _serviceVideo;

        public CategoryController(IUnitOfWork unitOfWork, IServiceCategory serviceCategory, IServiceVideo serviceVideo)
            : base(unitOfWork)
        {
            _serviceCategory = serviceCategory;
            _serviceVideo = serviceVideo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? pageNumber)
        {
            var category = await _serviceCategory.GetAllAsync(pageNumber);

            return ResponseAsync(category, _serviceCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Categoria não encontrada.");
            }

            var category = await _serviceCategory.GetByIdAsync(id);

            return ResponseAsync(category, _serviceCategory);
        }

        [HttpGet("{id}/videos")]
        public async Task<IActionResult> GetVideosByCategoryId(string id, int? pageNumber)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Categoria não encontrada.");
            }

            var category = await _serviceVideo.GetAllVideosByCategoryId(id, pageNumber);

            return ResponseAsync(category, _serviceCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid) return ModelStateErros();

            var request = new CreateCategoryRequest
            {
                Title = model.Title,
                Color = model.Color,
            };

            var response = await _serviceCategory.CreateAsync(request);

            return ResponseAsync(response, _serviceCategory);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Alter(string id, [FromBody] AlterCategoryViewModel model)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Categoria não encontrada.");
            }

            if (!ModelState.IsValid) return ModelStateErros();

            var request = new AlterCategoryRequest
            {
                Id = id,
                Title = model.Title,
                Color = model.Color,
            };

            var response = await _serviceCategory.AlterAsync(request);

            return ResponseAsync(response, _serviceCategory);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Categoria não encontrada.");
            }

            var result = await _serviceCategory.RemoveAsync(id);

            return ResponseAsync(result, _serviceCategory);
        }
    }
}
