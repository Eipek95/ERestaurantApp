using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.ViewModels.PasswordViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        [Display(Name = "Yeni Şifre :")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Şifreler Aynı Değil")]
        [Required(ErrorMessage = "Şifre Tekrar alanı boş geçilemez")]
        [Display(Name = "Yeni Şifre Tekrar :")]
        public string PasswordConfirm { get; set; }
    }
}
