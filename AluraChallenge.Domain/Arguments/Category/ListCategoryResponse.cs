using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Category
{
    public class ListCategoryResponse : IResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static explicit operator ListCategoryResponse(Entities.Category category)
        {
            return new ListCategoryResponse()
            {
                Id = category.Id,
                Title = category.Title,
                Color = category.Color,
            };
        }
    }
}
