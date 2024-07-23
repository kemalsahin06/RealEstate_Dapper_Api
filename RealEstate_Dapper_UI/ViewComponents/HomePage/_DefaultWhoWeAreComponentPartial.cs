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
            var responseMessage = await client.GetAsync("https://localhost:44346/api/WhoWeAreDetail");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                ViewBag.Title = value.Select(x=>x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x=>x.SubTitle).FirstOrDefault();
                ViewBag.desciription1 = value.Select(x=>x.Desciription1).FirstOrDefault();
                ViewBag.desciription2 = value.Select(x=>x.Desciription2).FirstOrDefault();
                return View();

            }
            return View();
        }
    }
}

