using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Video
{
    public class AlterVideoResponse : IResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string CategoryId { get; set; }

        public static explicit operator AlterVideoResponse(Entities.Video video)
        {
            return new AlterVideoResponse
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                Url = video.Url,        
                CategoryId = video.CategoryId,
            };
        }
    }
}
