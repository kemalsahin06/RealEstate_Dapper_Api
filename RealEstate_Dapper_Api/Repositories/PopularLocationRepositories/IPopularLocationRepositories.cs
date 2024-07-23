using RealEstate_Dapper_Api.Dtos.PoularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepositories
    {
        public Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        //void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        //void DeleteBottomGrid(int id);
        //void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        //Task<GetBottomGridDto> GetBottomGrid(int id);
    }
}
