using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PoularLocationDtos;
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

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            _ipopularLocationRepositories.CreatPopularLocation(createPopularLocationDto);
            return Ok(" Lokasyon kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _ipopularLocationRepositories.DeletePopularLocation(id);
            return Ok(" Lokasyon kısmı Silinmiştir");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopolarLocationDto)
        {
            _ipopularLocationRepositories.UpdatePopularLocation(updatePopolarLocationDto);
            return Ok("Lokasyon kısmı başarılı bir şekilde güncellendi");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _ipopularLocationRepositories.GetIDPopularLocation(id);
            return Ok(value);
        }
    }
}
