using AluraChallenge.Domain.Arguments;
using AluraChallenge.Domain.Arguments.Category;
using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces.Services.Base;
using AluraChallenge.Domain.Utils;
using System.Threading.Tasks;

namespace AluraChallenge.Domain.Interfaces.Services
{
    public interface IServiceCategory : IServiceBase
    {
        Task<ResponseBase> CreateAsync(CreateCategoryRequest request);

        Task<CategoryResponse> GetByIdAsync(string id);

        Task<Paginated<ListCategoryResponse, Category>> GetAllAsync(int? pageNumber);

        Task<ResponseBase> AlterAsync(AlterCategoryRequest request);

        Task<ResponseBase> RemoveAsync(string id);
    }
}
