using RealEstate_Dapper_Api.Dtos.PoularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepositories
    {
        public Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        Task CreatPopularLocation(CreatePopularLocationDto createPopularLocationDto);
        Task DeletePopularLocation(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
        Task<GetByIDPopularLocationDto> GetIDPopularLocation(int id);
    }
}
