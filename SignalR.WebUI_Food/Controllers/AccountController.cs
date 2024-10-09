using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.Extensions;
using SignalR.WEB_Food.Services;
using SignalR.WEB_Food.ViewModels.ForgetPasswordModels;
using SignalR.WEB_Food.ViewModels.LoginViewModels;
using SignalR.WEB_Food.ViewModels.PasswordViewModels;

namespace SignalR.WEB_Food.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;

        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
        {


            if (!ModelState.IsValid)
            {
                return View();
            }

            returnUrl = string.IsNullOrEmpty(returnUrl) || returnUrl == "/" ? Url.Action("Index", "MyProfile") : returnUrl;


            var hasUser = await _userManager.FindByEmailAsync(loginViewModel.Mail);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser!, loginViewModel.Password, loginViewModel.RememberMe, false);//cookie oluşturur
            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl!);
            }


            ModelState.AddModelErrorList(new List<string> { "Email veya Şifre Yanlış" });
            return View();
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }



        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordModel model)
        {
            var hasUser = await _userManager.FindByEmailAsync(model.Mail);

            if (hasUser == null)
            {
                TempData["ErrorMessage"] = "Bu email adresine sahip kullanıcı bulunamamıştır.";
                return RedirectToAction(nameof(AccountController.Login));
            }


            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);
            var passwordResetLink = Url.Action("ResetPassword", "Account", new { userId = hasUser.Id, token = passwordResetToken }, HttpContext.Request.Scheme);

            await _emailService.SendResetPasswordEmail(passwordResetLink, hasUser.Email);
            TempData["SuccessMessage"] = "Şifre yenileme linki,eposta adresinize gönderilmiştir.";
            return RedirectToAction(nameof(AccountController.Login));
        }

        [HttpGet]

        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"]!.ToString();
            var token = TempData["token"]!.ToString();

            if (userId == null || token == null)
            {
                throw new Exception("Bir Hata Meydana Geldi");
            }
            var hasUser = await _userManager.FindByIdAsync(userId);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Bulunanamamıştır.");
                return View();
            }

            var result = await _userManager.ResetPasswordAsync(hasUser, token, request.Password);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Şifreniz Başarıyla Yenilenmiştir.";
                return RedirectToAction(nameof(AccountController.Login));
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors);
            }
            return View();
        }


        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeVewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var checkOldPassword = await _userManager.CheckPasswordAsync(currentUser, request.PasswordOld);

            if (!checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Eski Şifreniz Yanlış");
                return View();
            }

            var resultChangePassword = await _userManager.ChangePasswordAsync(currentUser, request.PasswordOld, request.PasswordNew);
            if (!resultChangePassword.Succeeded)
            {
                ModelState.AddModelErrorList(resultChangePassword.Errors);
            }

            await _userManager.UpdateSecurityStampAsync(currentUser);
            TempData["SuccessMessage"] = "Şifreniz Başarıyla Değiştirilmiştir.Lütfen Tekrardan Giriş Yapınız";
            return RedirectToAction(nameof(AccountController.Logout), new { returnurl = "/Account/Login" });
        }
    }
}
