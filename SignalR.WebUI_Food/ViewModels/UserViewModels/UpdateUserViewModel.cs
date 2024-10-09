using SignalR.API_Common;
using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.ViewModels.UserViewModels
{
    public class UpdateUserViewModel
    {

        [EmailAddress(ErrorMessage = "Email Formatı Yanlıştır")]
        [Required(ErrorMessage = "Mail Adres alanı boş geçilemez")]
        [Display(Name = "Mail :")]
        public string Mail { get; set; } = null!;

        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [Display(Name = "Adı :")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [Display(Name = "Soyadı :")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez")]
        [Display(Name = "Kullanıcı Adı :")]
        public string Username { get; set; } = null!;


        [Display(Name = "Telefon Numarası :")]
        public string? Phone { get; set; }

        [Display(Name = "Doğum Tarihi:")]
        [DataType(DataType.Date)]
        public string? BirthDate { get; set; }

        [Required(ErrorMessage = "Şehir Alanı boş geçilemez")]
        [Display(Name = "Şehir:")]
        public string City { get; set; } = null!;
        [Display(Name = "Cinsiyet:")]
        public Gender? Gender { get; set; }
    }
}
