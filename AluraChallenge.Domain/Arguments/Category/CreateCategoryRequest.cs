using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Category
{
    public class CreateCategoryRequest : IRequest
    {
        public string Title { get; set; }

        public string Color { get; set; }
    }
}
