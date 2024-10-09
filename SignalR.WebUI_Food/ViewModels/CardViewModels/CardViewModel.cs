using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.ViewModels.CardViewModels
{
    public class CardViewModel
    {
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Address { get; set; }
        [Display(Name = "Şehir")]
        public string City { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string? Phone { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "Kart Sahibi")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string CardName { get; set; }
        [Display(Name = "Kart Numarası")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string CardNumber { get; set; }
        [Display(Name = "Son Kullanma Ayı")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string ExpirationMonth { get; set; }
        [Display(Name = "Son Kullanma Yılı")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string ExpirationYear { get; set; }
        [Display(Name = "Güvenlik Kodu")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Cvv { get; set; }
        [Display(Name = "Toplam Fiyat (Kdv Dahil)")]
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string BasketId { get; set; }
    }
}
