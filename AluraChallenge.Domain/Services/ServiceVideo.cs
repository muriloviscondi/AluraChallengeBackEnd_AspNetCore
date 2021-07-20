using AluraChallenge.Domain.Arguments.Video;
using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces.Repositories;
using AluraChallenge.Domain.Interfaces.Services;
using AluraChallenge.Domain.Utils;
using prmToolkit.NotificationPattern;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        #region Properties
        private readonly IRepositoryVideo _repositoryVideo;
        #endregion

        #region Constructor
        public ServiceVideo() { }

        public ServiceVideo(IRepositoryVideo repositoryVideo)
        {
            _repositoryVideo = repositoryVideo;
        }

        #endregion


        public async Task<ResponseBase> AlterAsync(AlterVideoRequest request)
        {
            if (request == null)
            {
                AddNotification("Video", "Preencha os dados.");
                return null;
            }

            var video = await _repositoryVideo.GetByIdAsync(request.Id, false);

            if (video == null)
            {
                AddNotification("Video", "Video não encontrado.");
                return null;
            }

            video.Alter(request);

            AddNotifications(video);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryVideo.Update(video);

            return new ResponseBase();
        }

        public async Task<ResponseBase> CreateAsync(CreateVideoRequest request)
        {
            if (request == null)
            {
                AddNotification("Video", "Preencha os campos obrigatórios");
                return null;
            }

            var video = new Video(request.Title, request.Description, request.Url);

            AddNotifications(video);

            if (IsInvalid())
            {
                return null;
            }

            await _repositoryVideo.InsertAsync(video);

            return new ResponseBase();
        }

        public async Task<Paginated<ListVideoResponse, Video>> GetAllAsync(int? pageNumber)
        {
            IQueryable<Video> video;

            video = _repositoryVideo.GetAllOrderBy(true, c => c.Title, true);

            return await Paginated<ListVideoResponse, Video>.CreateAsync(video, pageNumber ?? 1, 10);
        }

        public async Task<VideoResponse> GetByIdAsync(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                AddNotification("Video", "Video não encontrado.");
                return null;
            }

            var video = await _repositoryVideo.GetByIdAsync(id);

            if (video == null)
            {
                AddNotification("Video", "Video não encontrado.");
                return null;
            }

            return (VideoResponse)video;
        }

        public async Task<ResponseBase> RemoveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                AddNotification("Id", "Video não encontrada.");
                return null;
            }

            var video = await _repositoryVideo.GetByIdAsync(id, false);

            if (IsInvalid()) return null;

            _repositoryVideo.Remove(video);

            return new ResponseBase(message: "Video excluído com sucesso.");
        }
    }
}
