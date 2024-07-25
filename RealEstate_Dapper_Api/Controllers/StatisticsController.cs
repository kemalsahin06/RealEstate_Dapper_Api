using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_statisticsRepository.ActiveCategoryCount());
        }

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(_statisticsRepository.ActiveEmployeeCount());
        }


        [HttpGet("ApartmenCount")]
        public IActionResult ApartmenCount()
        {
            return Ok(_statisticsRepository.ApartmenCount());
        }

        [HttpGet("AverangeProductPriceByRent")]
        public IActionResult AverangeProductPriceByRent()
        {
            return Ok(_statisticsRepository.AverangeProductPriceByRent());
        }


        [HttpGet("AverangeProductPriceBySale")]
        public IActionResult AverangeProductPriceBySale()
        {
            return Ok(_statisticsRepository.AverangeProductPriceBySale());
        }


        [HttpGet("AverangeRoomCount")]
        public IActionResult AverangeRoomCount()
        {
            return Ok(_statisticsRepository.AverangeRoomCount());
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_statisticsRepository.CategoryCount());
        }

        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
        {
            return Ok(_statisticsRepository.CityNameByMaxProductCount());
        }
    }
}
