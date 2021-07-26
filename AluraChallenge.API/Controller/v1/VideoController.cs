using AluraChallenge.API.Controller.Base;
using AluraChallenge.API.Models;
using AluraChallenge.Domain.Arguments.Video;
using AluraChallenge.Domain.Interfaces.Services;
using AluraChallenge.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AluraChallenge.API.Controller.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VideoController : BaseController
    {
        private readonly IServiceCategory _serviceCategory;
        private readonly IServiceVideo _serviceVideo;

        public VideoController(IUnitOfWork unitOfWork, IServiceVideo serviceVideo, IServiceCategory serviceCategory)
            : base(unitOfWork)
        {
            _serviceVideo = serviceVideo;
            _serviceCategory = serviceCategory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? pageNumber)
        {
            var video = await _serviceVideo.GetAllAsync(pageNumber);

            return ResponseAsync(video, _serviceVideo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Video não encontrado.");
            }

            var video = await _serviceVideo.GetByIdAsync(id);

            return ResponseAsync(video, _serviceVideo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVideoViewModel model)
        {
            if (!ModelState.IsValid) return ModelStateErros();

            var category = await _serviceCategory.GetByIdAsync(model.CategoryId);

            if (category == null)
            {
                return BadRequest(new { errors = _serviceCategory.Notifications });
            }

            var request = new CreateVideoRequest
            {
                Title = model.Title,
                Description = model.Description,
                Url = model.Url,
                CategoryId = model.CategoryId,
            };

            var response = await _serviceVideo.CreateAsync(request);

            return ResponseAsync(response, _serviceVideo);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Alter(string id, [FromBody] AlterVideoViewModel model)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Video não encontrado.");
            }

            if (!ModelState.IsValid) return ModelStateErros();

            var category = await _serviceCategory.GetByIdAsync(model.CategoryId);

            if (category == null)
            {
                return BadRequest(new { errors = _serviceCategory.Notifications });
            }

            var request = new AlterVideoRequest
            {
                Id = id,
                Title = model.Title,
                Description = model.Description,
                Url = model.Url,
                CategoryId = model.CategoryId,
            };

            var response = await _serviceVideo.AlterAsync(request);

            return ResponseAsync(response, _serviceVideo);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Video não encontrado.");
            }

            var result = await _serviceVideo.RemoveAsync(id);

            return ResponseAsync(result, _serviceVideo);
        }
    }
}
