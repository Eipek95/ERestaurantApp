using System.ComponentModel.DataAnnotations;

namespace SignalR.WEB_Food.Models
{
    public class UpdateRoleViewModel
    {
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Name { get; set; } = null!;
    }
}
