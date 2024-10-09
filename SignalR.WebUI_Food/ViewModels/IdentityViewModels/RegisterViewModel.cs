using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.ViewModels.IdentityViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [Display(Name = "Adınız :")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [Display(Name = "Soyadınız :")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Ad alanı boş geçilemez")]
        [Display(Name = "Kullanıcı Ad :")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email Formatı Yanlıştır")]
        [Required(ErrorMessage = "Mail Adres alanı boş geçilemez")]
        [Display(Name = "Mail :")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir!")]
        public string Password { get; set; }
    }
}
