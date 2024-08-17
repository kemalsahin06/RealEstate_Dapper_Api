using RealEstate_Dapper_Api.Dtos.CatageryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        public Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateService(CreateServiceDto createServiceDto);
        Task DeleteService(int id);
        Task UpdateService(UpdateServiceDto updateServiceDto);
        Task<GetByIDServiceDtocs> GetIDService(int id);
    }
}
