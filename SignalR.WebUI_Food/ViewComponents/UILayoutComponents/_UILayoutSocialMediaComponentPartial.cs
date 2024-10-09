using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WEB_Food.ViewModels.SocialMediaViewModels;

namespace SignalR.WEB_Food.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7146/api/SocialMedia");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultSocialMediaViewModel>>(jsonData);
			return View(values);
		}
	}
}
