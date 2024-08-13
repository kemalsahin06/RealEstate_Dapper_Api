using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAminityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAminityRepositories
{
    public class PropertyAminityRepository : IPropertyAminityRepository
    {
        private readonly Context _context;
        public PropertyAminityRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPropertyAMENİTYByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id)
        {
            string query = "Select PropertyAmenityId,Title From PropertyAmenity Inner Join Amenity On Amenity.AmenityId=PropertyAmenity.AmenityId Where PropertyId=@propertyId And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAMENİTYByStatusTrueDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
