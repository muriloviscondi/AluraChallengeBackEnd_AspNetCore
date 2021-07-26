using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Category
{
    public class AlterCategoryRequest : IRequest
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }
    }
}
