using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CatageryDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var resposeMessage = await client.GetAsync("https://localhost:44346/api/Categories");
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsondata = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> PartialSearch()
        {
            var client = _httpClientFactory.CreateClient();
            var resposeMessage = await client.GetAsync("https://localhost:44346/api/Categories");
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsondata = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
                return PartialView(values);
            }
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialSearch(string searchKeyValue, string city, int propertyCategoryId)
        {
            TempData["searchKeyValue"] = searchKeyValue;
            TempData["propertyCategoryId"] = propertyCategoryId;
            TempData["city"] = city;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
