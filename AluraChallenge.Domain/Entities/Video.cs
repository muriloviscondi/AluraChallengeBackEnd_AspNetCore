using AluraChallenge.Domain.Arguments.Video;
using AluraChallenge.Domain.Entities.Base;
using prmToolkit.NotificationPattern;

namespace AluraChallenge.Domain.Entities
{
    public class Video : BaseEntity
    {
        public Video(string title, string description, string url, string categoryId)
        {
            Title = title;
            Description = description;
            Url = url;
            CategoryId = categoryId;

            new AddNotifications<Video>(this).IfNullOrEmpty(x => x.Title, "O campo de título é obrigatório.");
            new AddNotifications<Video>(this).IfNullOrEmpty(x => x.Description, "O campo de descrição é obrigatório.");
            new AddNotifications<Video>(this).IfNotUrl(x => x.Url, "A url é obrigatória.");
            new AddNotifications<Video>(this).IfNullOrEmpty(x => x.CategoryId, "O campo CategoryId é obrigatório.");
        }

        public string Title { get; private set; }

        public string Description { get; private set; }
        
        public string Url { get; private set; }

        public string CategoryId { get; private set; }

        public Category Category { get; private set; }

        public void Alter(AlterVideoRequest request)
        {
            Title = request.Title;
            Description = request.Description;
            Url = request.Url;
            CategoryId = request.CategoryId;

            new AddNotifications<Video>(this).IfNullOrEmpty(x => x.Title, "O campo de título é obrigatório.");
            new AddNotifications<Video>(this).IfNullOrEmpty(x => x.Description, "O campo de descrição é obrigatório.");
            new AddNotifications<Video>(this).IfNotUrl(x => x.Url, "A url é obrigatória.");
            new AddNotifications<Video>(this).IfNullOrEmpty(x => x.CategoryId, "O campo CategoryId é obrigatório.");
        }
    }
}
