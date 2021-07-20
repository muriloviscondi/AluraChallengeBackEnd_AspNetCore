using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Video
{
    public class AlterVideoRequest : IRequest
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}
