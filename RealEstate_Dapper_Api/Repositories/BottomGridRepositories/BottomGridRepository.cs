using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) values (@icon,@title,@description)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@icon", createBottomGridDto.Icon);
            parametrs.Add("@title", createBottomGridDto.Title);
            parametrs.Add("@description", createBottomGridDto.Description);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);

            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridID=@bottomGridID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {

            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid where BottomGridID=@bottomGridID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parametrs); // buda geriye deger döndürdügüm i.in böyle bir kullanış yaptım
                return values;

            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@icon,Title=@title, Description=@description where BottomGridID=@bottomGridID ";
            var parametrs = new DynamicParameters();
            parametrs.Add("@icon", updateBottomGridDto.Icon);
            parametrs.Add("@title", updateBottomGridDto.Title);
            parametrs.Add("@description", updateBottomGridDto.Description);
            parametrs.Add("@bottomGridID", updateBottomGridDto.BottomGridID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
