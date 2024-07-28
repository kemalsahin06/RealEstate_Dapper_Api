using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.PoularLocationDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepositories : IPopularLocationRepositories
    {
        private readonly Context _context;

        public PopularLocationRepositories(Context context)
        {
            _context = context;
        }

        public async void CreatPopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) values (@cityName,@imageUrl)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@cityName", createPopularLocationDto.CityName);
            parametrs.Add("@imageUrl", createPopularLocationDto.ImageUrl);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);

            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where LocationID=@locationID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDPopularLocationDto> GetIDPopularLocation(int id)
        {
            string query = "Select * From PopularLocation where LocationID=@locationID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, parametrs); // buda geriye deger döndürdügüm i.in böyle bir kullanış yaptım
                return values;

            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation Set CityName=@cityName,ImageUrl=@imageUrl  where LocationID=@locationID ";
            var parametrs = new DynamicParameters();
            parametrs.Add("@cityName", updatePopularLocationDto.CityName);
            parametrs.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            parametrs.Add("@locationID", updatePopularLocationDto.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
