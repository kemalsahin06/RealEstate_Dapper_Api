using Dapper;
using RealEstate_Dapper_Api.Dtos.CatageryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title,Price,City,District,CoverImage,Address,Description,Type,DealOfTheDay,AdvertisementDate,ProductStatus,ProductCategory,EmployeeID) values (@Title,@Price,@City,@District,@CoverImage,@Address,@Description,@Type,@DealOfTheDay,@AdvertisementDate,@ProductStatus,@ProductCategory,@EmployeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.title);
            parameters.Add("@Price", createProductDto.price);
            parameters.Add("@City", createProductDto.city);
            parameters.Add("@District", createProductDto.district);
            parameters.Add("@CoverImage", createProductDto.coverImage);
            parameters.Add("@Address", createProductDto.address);
            parameters.Add("@Description", createProductDto.desciription);
            parameters.Add("@Type", createProductDto.type);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDto.productStatus);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmployeeID", createProductDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWhitCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City, District, Category.CategoryName , CoverImage,Type,Address , DealOfTheDay  From Product inner join category on Product.ProductCategory = Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWhitCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "SELECT TOP(5)   Product.ProductID,   Product.Title,  Product.Price,  Product.City,    Product.District,    Product.ProductCategory,    Category.CategoryName,  Product.AdvertisementDate FROM    Product INNER JOIN     Category ON     Product.ProductCategory = Category.CategoryID  WHERE    Product.Type = 'Kiralık' ORDER BY     Product.ProductID DESC;";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID,Title,Price,City, District, Category.CategoryName , CoverImage,Type,Address , DealOfTheDay  From Product inner join category on Product.ProductCategory = Category.CategoryID where EmployeeID =@employeeID and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID,Title,Price,City, District, Category.CategoryName , CoverImage,Type,Address , DealOfTheDay  From Product inner join category on Product.ProductCategory = Category.CategoryID where EmployeeID =@employeeID and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,parameters);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIDDto> GetProductByProductID(int id)
        {
            string query = "Select ProductID,Title,Price,City, District, Category.CategoryName , CoverImage,Type,Address , DealOfTheDay , AdvertisementDate  From Product inner join category on Product.ProductCategory = Category.CategoryID where @ProductId=@productıd";
            var parametrs = new DynamicParameters();
            parametrs.Add("@productıd", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIDDto>(query, parametrs);
                return values.FirstOrDefault();
            }
           
        }

        public async Task<GetProductDetailByIdDto> GetProductDeyailByProductID(int id)
        {
            string query = "Select * From ProductDetails Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeFalse(int id)
        {

            string query = " Update Product  Set DealOfTheDay=0 where ProductID =@productId ";
            var parametrs = new DynamicParameters();
            parametrs.Add("@productId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);

            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {

            string query = " Update Product  Set DealOfTheDay=1 where ProductID =@productId ";
            var parametrs = new DynamicParameters();
            parametrs.Add("@productId",id);
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);

            }

        }
    }
}
