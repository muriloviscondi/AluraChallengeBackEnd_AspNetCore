using AluraChallenge.Domain.Arguments.Category;
using AluraChallenge.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace AluraChallenge.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category(string title, string color)
        {
            Title = title;
            Color = color;

            new AddNotifications<Category>(this).IfNullOrEmpty(x => x.Title, "O campo de título é obrigatório.");
            new AddNotifications<Category>(this).IfNullOrEmpty(x => x.Color, "O campo de cor é obrigatório.");
        }

        public string Title { get; private set; }

        public string Color { get; private set; }
        
        public ICollection<Video> Videos { get; set; }

        public void Alter(AlterCategoryRequest request)
        {
            Title = request.Title;
            Color = request.Color;

            new AddNotifications<Category>(this).IfNullOrEmpty(x => x.Title, "O campo de título é obrigatório.");
            new AddNotifications<Category>(this).IfNullOrEmpty(x => x.Color, "O campo de cor é obrigatório.");        
        }
    }
}
