using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailsDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44346/api/WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync("https://localhost:44346/api/Service");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

                ViewBag.Title = value.Select(x=>x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x=>x.SubTitle).FirstOrDefault();
                ViewBag.desciription1 = value.Select(x=>x.Desciription1).FirstOrDefault();
                ViewBag.desciription2 = value.Select(x=>x.Desciription2).FirstOrDefault();
                return View(value2);

            }
            return View();
        }
    }
}

