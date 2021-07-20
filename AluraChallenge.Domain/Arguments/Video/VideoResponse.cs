using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Video
{
    public class VideoResponse : IResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public static explicit operator VideoResponse(Entities.Video video)
        {
            return new VideoResponse
            {

                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                Url = video.Url,
            };
        }
    }
}
