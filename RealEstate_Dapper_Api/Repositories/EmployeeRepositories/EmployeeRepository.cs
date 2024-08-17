using Dapper;
using RealEstate_Dapper_Api.Dtos.CatageryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status ) values (@name,@title,@mail,@phoneNumber,@imageUrl,@status)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@name", createEmployeeDto.Name);
            parametrs.Add("@title", createEmployeeDto.Title);
            parametrs.Add("@mail", createEmployeeDto.Mail);
            parametrs.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
            parametrs.Add("@imageUrl", createEmployeeDto.ImageUrl);
            parametrs.Add("@status", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);

            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public Task GetAllEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {

            string query = "Select * From Employee where EmployeeID=@employeeID";
            var parametrs = new DynamicParameters();
            parametrs.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parametrs); // buda geriye deger döndürdügüm i.in böyle bir kullanış yaptım
                return values;

            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = " Update Employee  Set Name=@name,Title=@title,Mail=@mail,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status where EmployeeID=@employeeID" ;
            var parametrs = new DynamicParameters();
            parametrs.Add("@name", updateEmployeeDto.Name);
            parametrs.Add("@title", updateEmployeeDto.Title);
            parametrs.Add("@mail", updateEmployeeDto.Mail);
            parametrs.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            parametrs.Add("@imageUrl", updateEmployeeDto.ImageUrl);
            parametrs.Add("@status", updateEmployeeDto.Status);
            parametrs.Add("@employeeID", updateEmployeeDto.EmployeeID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);

            }
        }
    }
}
