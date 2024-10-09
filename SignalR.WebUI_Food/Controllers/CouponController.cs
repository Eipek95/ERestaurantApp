using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.ViewModels.CouponUserViewModels;
using SignalR.WEB_Food.ViewModels.CouponViewModels;
using System.Text;

namespace SignalR.WEB_Food.Controllers
{
    public class CouponController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public CouponController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IActionResult> CouponList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Coupon");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCouponViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCoupon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponViewModel createCouponViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCouponViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7146/api/Coupon", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CouponList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCoupon(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7146/api/Coupon/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CouponList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCoupon(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/Coupon/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCouponViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponViewModel updateCouponViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCouponViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7146/api/Coupon/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("CouponList");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GiveACoupon(int id)
        {
            var userList = await _userManager.Users.ToListAsync();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/CouponUser/GetCouponUserList/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCouponUserViewModel>>(jsonData);

            var userIdsNotInValues = userList.Select(u => u.Id).Except(values.Select(v => v.AppUserId));
            var usersNotInValues = userList.Where(u => userIdsNotInValues.Contains(u.Id)).ToList();
            var usersInValues = userList.Where(u => values.Select(x => x.AppUserId).Contains(u.Id)).ToList();



            List<SelectListItem> uList = (from users in usersNotInValues
                                          select new SelectListItem
                                          {
                                              Text = users.Name + " " + users.Surname,
                                              Value = users.Id.ToString()
                                          }).ToList();

            List<SelectListItem> uList2 = (from users in usersInValues
                                           select new SelectListItem
                                           {
                                               Text = users.Name + " " + users.Surname,
                                               Value = users.Id.ToString()
                                           }).ToList();

            ViewBag.userList = uList;
            ViewBag.userList2 = uList2;
            ViewBag.CouponId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GiveACoupon(int id, List<string> targetList)
        {
            var client = _httpClientFactory.CreateClient();
            CreateCouponUserViewModel model;
            List<CreateCouponUserViewModel> models = new List<CreateCouponUserViewModel>();
            StringContent stringContent;



            foreach (var item in targetList)
            {
                model = new()
                {
                    AppUserId = item,
                    CouponId = id,
                    CreatedDate = DateTime.Now,
                    Status = true
                };
                models.Add(model);
            }


            var jsonData = JsonConvert.SerializeObject(models);
            stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7146/api/CouponUser/CreateListCouponUser", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CouponList");

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CouponUserList(int couponId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/CouponUser/GetCouponUserListWithUserByCouponId/{couponId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCouponUserListWithUserViewModel>>(jsonData);


            if (responseMessage.IsSuccessStatusCode)
            {
                return View(values);

            }

            return View();
        }
        [HttpGet]

        public async Task<IActionResult> CouponUserListDelete(int couponUserId, int couponId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7146/api/CouponUser/{couponUserId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CouponUserList", new { couponId = couponId });
            }


            return View();
        }
    }
}
