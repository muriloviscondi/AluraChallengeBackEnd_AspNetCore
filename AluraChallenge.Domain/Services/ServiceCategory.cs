using AluraChallenge.Domain.Arguments;
using AluraChallenge.Domain.Arguments.Category;
using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces.Repositories;
using AluraChallenge.Domain.Interfaces.Services;
using AluraChallenge.Domain.Utils;
using prmToolkit.NotificationPattern;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge.Domain.Services
{
    public class ServiceCategory : Notifiable, IServiceCategory
    {
        #region Properties
        private readonly IRepositoryCategory _repositoryCategory;
        #endregion

        #region Constructor
        public ServiceCategory() { }

        public ServiceCategory(IRepositoryCategory repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        #endregion


        public async Task<ResponseBase> AlterAsync(AlterCategoryRequest request)
        {
            if (request == null)
            {
                AddNotification("Category", "Preencha os dados.");
                return null;
            }

            var category = await _repositoryCategory.GetByIdAsync(request.Id, false);

            if (category == null)
            {
                AddNotification("Category", "Categoria não encontrada.");
                return null;
            }

            category.Alter(request);

            AddNotifications(category);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryCategory.Update(category);

            return new ResponseBase();
        }

        public async Task<ResponseBase> CreateAsync(CreateCategoryRequest request)
        {
            if (request == null)
            {
                AddNotification("Category", "Preencha os campos obrigatórios");
                return null;
            }

            var category = new Category(request.Title, request.Color);

            AddNotifications(category);

            if (IsInvalid())
            {
                return null;
            }

            await _repositoryCategory.InsertAsync(category);

            return new ResponseBase();
        }

        public async Task<Paginated<ListCategoryResponse, Category>> GetAllAsync(int? pageNumber)
        {
            IQueryable<Category> category;

            category = _repositoryCategory.GetAllOrderBy(true, c => c.Title, true);

            return await Paginated<ListCategoryResponse, Category>.CreateAsync(category, pageNumber ?? 1, 10);
        }

        public async Task<CategoryResponse> GetByIdAsync(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                AddNotification("Category", "Categoria não encontrada.");
                return null;
            }

            var category = await _repositoryCategory.GetByIdAsync(id);

            if (category == null)
            {
                AddNotification("Category", "Categoria não encontrada.");
                return null;
            }

            return (CategoryResponse)category;
        }

        public async Task<ResponseBase> RemoveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                AddNotification("Id", "Categoria não encontrada.");
                return null;
            }

            var category = await _repositoryCategory.GetByIdAsync(id, false);

            if (IsInvalid()) return null;

            _repositoryCategory.Remove(category);

            return new ResponseBase(message: "Categoria excluída com sucesso.");
        }
    }
}
