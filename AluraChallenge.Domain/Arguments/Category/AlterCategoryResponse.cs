using AluraChallenge.Domain.Interfaces.Arguments;

namespace AluraChallenge.Domain.Arguments.Category
{
    public class AlterCategoryResponse : IResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public static explicit operator AlterCategoryResponse(Entities.Category category)
        {
            return new AlterCategoryResponse
            {
                Id = category.Id,
                Title = category.Title,
                Color = category.Color,         
            };
        }
    }
}
