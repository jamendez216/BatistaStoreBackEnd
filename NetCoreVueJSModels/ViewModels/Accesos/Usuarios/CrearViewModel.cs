using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreVueJSModels.Models.Accesos.Usuarios
{
    public class CrearViewModel
    {
        [Required]
        public int idrol { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Name value must be between 10 and 100 characters")]
        public string nombre { get; set; }
        [Required]
        public string tipo_documento { get; set; }
        [Required]
        public string num_documento { get; set; }
        public string direccion { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "phone value must be between 10 and 13 characters")]
        public string telefono { get; set; }
        [Required]
        [EmailAddress]
        public string email{ get; set; }
        [Required]
        public string password{ get; set; }
    }
}
