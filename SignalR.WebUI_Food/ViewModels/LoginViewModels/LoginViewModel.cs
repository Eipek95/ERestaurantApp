using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.ViewModels.LoginViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Email Formatı Yanlıştır")]
        [Required(ErrorMessage = "Mail Adres alanı boş geçilemez")]
        [Display(Name = "Mail :")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
