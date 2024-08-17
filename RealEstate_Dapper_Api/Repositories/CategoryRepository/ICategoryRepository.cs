using RealEstate_Dapper_Api.Dtos.CatageryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByIDCategoryDto> GetCategory(int id);

    }
}
