using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.ViewModels.PasswordViewModels
{
    public class PasswordChangeVewModel
    {
        [Required(ErrorMessage = "Eski Şifre alanı boş geçilemez")]
        [Display(Name = "Eski Şifre :")]
        public string PasswordOld { get; set; } = null!;

        [Required(ErrorMessage = "Yeni Şifre alanı boş geçilemez")]
        [Display(Name = "Yeni Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir!")]
        public string PasswordNew { get; set; } = null!;

        [Compare(nameof(PasswordNew), ErrorMessage = "Şifreler Aynı Değil")]
        [Required(ErrorMessage = "Yeni Şifre Tekrar alanı boş geçilemez")]
        [Display(Name = "Yeni Şifre Tekrar :")]
        public string PasswordNewConfirm { get; set; } = null!;
    }
}
