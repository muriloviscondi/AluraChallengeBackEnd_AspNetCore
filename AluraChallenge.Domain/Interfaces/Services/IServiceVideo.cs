using AluraChallenge.Domain.Arguments;
using AluraChallenge.Domain.Arguments.Video;
using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces.Services.Base;
using AluraChallenge.Domain.Utils;
using System.Threading.Tasks;

namespace AluraChallenge.Domain.Interfaces.Services
{
    public interface IServiceVideo : IServiceBase
    {
        Task<ResponseBase> CreateAsync(CreateVideoRequest request);

        Task<VideoResponse> GetByIdAsync(string id);

        Task<Paginated<ListVideoResponse, Video>> GetAllVideosByCategoryId(string categoryId, int? pageNumber);

        Task<Paginated<ListVideoResponse, Video>> GetAllAsync(int? pageNumber);

        Task<ResponseBase> AlterAsync(AlterVideoRequest request);

        Task<ResponseBase> RemoveAsync(string id);
    }
}
