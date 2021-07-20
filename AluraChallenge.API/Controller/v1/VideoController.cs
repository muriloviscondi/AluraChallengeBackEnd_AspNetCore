using AluraChallenge.API.Controller.Base;
using AluraChallenge.API.Models;
using AluraChallenge.Domain.Arguments.Video;
using AluraChallenge.Domain.Interfaces.Services;
using AluraChallenge.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AluraChallenge.API.Controller.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VideoController : BaseController
    {
        private readonly IServiceVideo _serviceVideo;

        public VideoController(IUnitOfWork unitOfWork, IServiceVideo serviceVideo)
            : base(unitOfWork)
        {
            _serviceVideo = serviceVideo;
        }

        [HttpGet("All")]
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

            var request = new CreateVideoRequest
            {
                Title = model.Title,
                Description = model.Description,
                Url = model.Url
            };

            var response = await _serviceVideo.CreateAsync(request);

            return ResponseAsync(response, _serviceVideo);
        }

        [Route("alter/{id}")]
        [HttpPut]
        public async Task<IActionResult> Alter(string id, [FromBody] AlterVideoViewModel model)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Video não encontrado.");
            }

            if (!ModelState.IsValid) return ModelStateErros();

            var request = new AlterVideoRequest
            {
                Id = id,
                Title = model.Title,
                Description = model.Description,
                Url = model.Url
            };

            var response = await _serviceVideo.AlterAsync(request);

            return ResponseAsync(response, _serviceVideo);
        }

        [Route("remove/{id}")]
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
