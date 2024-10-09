using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WEB_Food.ViewModels.CategoryViewModels;
using SignalR.WEB_Food.ViewModels.ProductViewModels;

namespace SignalR.WEB_Food.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductViewModel>>(jsonData);


            var responseMessage2 = await client.GetAsync("https://localhost:7146/api/Category");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(jsonData2);

            var tupleModel = new Tuple<List<ResultProductViewModel>, List<ResultCategoryViewModel>>(values, values2);
            return View(tupleModel);
        }
    }
}
