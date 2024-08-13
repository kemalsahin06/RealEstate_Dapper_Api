using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAminityRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAminitiesController : ControllerBase
    {
        private readonly IPropertyAminityRepository _propertyAminityRepository;

        public PropertyAminitiesController(IPropertyAminityRepository propertyAminityRepository)
        {
            _propertyAminityRepository = propertyAminityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ResultPropertyAmenityByStatusTrue(int id)
        {
            var values = await _propertyAminityRepository.ResultPropertyAmenityByStatusTrue(id);
            return Ok(values);
        }
    }
}
