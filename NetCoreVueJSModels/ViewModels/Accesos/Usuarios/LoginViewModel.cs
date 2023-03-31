using System.ComponentModel.DataAnnotations;

namespace NetCoreVueJSModels.Models.Accesos.Usuarios
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
