using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepositories _ipopularLocationRepositories;

        public PopularLocationsController(IPopularLocationRepositories ipopularLocationRepositories)
        {
            _ipopularLocationRepositories = ipopularLocationRepositories;
        }

        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var value = await _ipopularLocationRepositories.GetAllPopularLocationAsync();
            return Ok(value);
        }
    }
}
