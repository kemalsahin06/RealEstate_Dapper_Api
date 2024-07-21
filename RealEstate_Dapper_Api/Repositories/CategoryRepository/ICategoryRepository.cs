using RealEstate_Dapper_Api.Dtos.CatageryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByIDCategoryDto> GetCategory(int id);

    }
}
