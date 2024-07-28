using RealEstate_Dapper_Api.Dtos.PoularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepositories
    {
        public Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        void CreatPopularLocation(CreatePopularLocationDto createPopularLocationDto);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
        Task<GetByIDPopularLocationDto> GetIDPopularLocation(int id);
    }
}
