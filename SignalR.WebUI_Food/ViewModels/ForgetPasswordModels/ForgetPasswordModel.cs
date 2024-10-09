using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.ViewModels.ForgetPasswordModels
{
    public class ForgetPasswordModel
    {
        [EmailAddress(ErrorMessage = "Email Formatı Yanlıştır")]
        [Required(ErrorMessage = "Mail Adres alanı boş geçilemez")]
        [Display(Name = "Mail :")]
        public string Mail { get; set; }
    }
}
