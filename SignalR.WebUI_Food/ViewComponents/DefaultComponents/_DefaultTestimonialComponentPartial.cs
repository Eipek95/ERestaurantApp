using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WEB_Food.ViewModels.TestimonialViewModels;

namespace SignalR.WEB_Food.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Testimonial");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialViewModel>>(jsonData);


            return View(values);
        }
    }
}
