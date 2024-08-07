using RealEstate_Dapper_Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositories
{
    public class ProductImagesRepository : IProductImagesRepository
    {
        public Task<GetProductImageByProductIdDto> GetProductImageByProductId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
