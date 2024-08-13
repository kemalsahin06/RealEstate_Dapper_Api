using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        public Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
        Task<List<ResultProductWhitCategoryDto>> GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
        Task CreateProduct(CreateProductDto createProductDto);
        Task<GetProductByProductIDDto> GetProductByProductID(int id);
        Task<GetProductDetailByIdDto> GetProductDeyailByProductID(int id);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchkeyValue,int propertyCategoryId,string city);

    }
}
