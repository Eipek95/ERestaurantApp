using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Name { get; set; } = null!;
    }
}
