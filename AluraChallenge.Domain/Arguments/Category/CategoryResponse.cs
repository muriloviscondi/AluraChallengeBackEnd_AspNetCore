using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Category
{
    public class CategoryResponse : IResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static explicit operator CategoryResponse(Entities.Category category)
        {
            return new CategoryResponse
            {

                Id = category.Id,
                Title = category.Title,
                Color = category.Color,
            };
        }
    }
}
