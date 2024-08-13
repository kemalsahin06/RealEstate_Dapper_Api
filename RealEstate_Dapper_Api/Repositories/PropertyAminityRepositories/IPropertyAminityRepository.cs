using RealEstate_Dapper_Api.Dtos.PropertyAminityDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyAminityRepositories
{
    public interface IPropertyAminityRepository
    {
        Task<List<ResultPropertyAMENİTYByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);

    }
}
