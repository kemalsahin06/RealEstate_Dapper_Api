using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        public Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        //void CreateService(CreateServiceDto createServiceDto);
        //void DeleteService(int id);
        //void UpdateService(UpdateServiceDto updateServiceDto);
        //Task<GetByIDServiceDtocs> GetIDService(int id);
    }
}
