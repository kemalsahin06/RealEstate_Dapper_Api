using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PropertyAminityDtos;

namespace RealEstate_Dapper_UI.ViewComponents.SingleProperty
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/PropertyAminities?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAMENİTYByStatusTrueDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
