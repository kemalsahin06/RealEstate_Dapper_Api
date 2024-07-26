using Dapper;
using RealEstate_Dapper_Api.Dtos.CatageryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{

    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }
        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,SubTitle,Desciription1,Desciription2) values (@title,@subTitle,@desciription1,@desciription2)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@title", createWhoWeAreDetailDto.Title);
            parametrs.Add("@subTitle", createWhoWeAreDetailDto.SubTitle);
            parametrs.Add("@desciription1", createWhoWeAreDetailDto.Desciription1);
            parametrs.Add("@desciription2", createWhoWeAreDetailDto.Desciription2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);

            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail where WhoWeAreDetailID=@whoWeAreDetailID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parametrs); // buda geriye deger döndürdügüm i.in böyle bir kullanış yaptım
                return values;

            }
        }

        public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,SubTitle=@subtitle , Desciription1=@desciription1 ,Desciription2=@desciription2 where WhoWeAreDetailID=@whoWeAreDetailID ";
            var parametrs = new DynamicParameters();
            parametrs.Add("@title", updateWhoWeAreDetailDto.Title);
            parametrs.Add("@subtitle", updateWhoWeAreDetailDto.SubTitle);
            parametrs.Add("@desciription1", updateWhoWeAreDetailDto.Desciription1);
            parametrs.Add("@desciription2", updateWhoWeAreDetailDto.Desciription2);
            parametrs.Add("@whoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
