using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.Extensions;
using SignalR.WEB_Food.ViewModels.UserViewModels;

namespace SignalR.WEB_Food.Controllers
{

    public class MyProfileController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public MyProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.currentUserId = currentUser!.Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(MyProfileController.Index));
            }
            var currentUser = await _userManager.GetUserAsync(User);
            //var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);
            currentUser!.Name = request.Name;
            currentUser!.Surname = request.Surname;
            currentUser!.Email = request.Mail;
            currentUser!.PhoneNumber = request.Phone;
            currentUser!.City = request.City;
            currentUser!.Gender = request.Gender;
            currentUser.UserName = request.Username;

            var updateToUserResult = await _userManager.UpdateAsync(currentUser);


            if (!updateToUserResult.Succeeded)
            {
                ModelState.AddModelErrorList(updateToUserResult.Errors);
                return View(new UpdateUserViewModel
                {
                    Name = currentUser!.Name,
                    Surname = currentUser!.Surname,
                    Mail = currentUser!.Email!,
                    Username = currentUser!.UserName!,
                    Phone = currentUser!.PhoneNumber,
                    City = currentUser!.City,
                    Gender = currentUser!.Gender,
                });
            }
            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(currentUser, true);

            TempData["SuccessMessage"] = "Üye bilgileri Başarıyla Güncellenmiştir.";
            return View(new UpdateUserViewModel
            {
                Name = currentUser!.Name,
                Surname = currentUser!.Surname,
                Mail = currentUser!.Email!,
                Username = currentUser!.UserName!,
                Phone = currentUser!.PhoneNumber,
                City = currentUser!.City,
                Gender = currentUser!.Gender,
            });
        }
    }
}
