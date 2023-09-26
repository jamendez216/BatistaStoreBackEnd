using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCoreVueJSModels.Sales
{
    public class CPerson
    {
        public int idpersona { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Person type must be between 3 and 20 characters")]
        public string tipo_persona { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "name must be between 3 and 100 characters")]
        public string nombre { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Document type must be between 3 and 20 characters")]
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 70 characters")]
        public string direccion { get; set; }
        public string telefono { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "email must be between 3 and 20 characters")]
        public string email { get; set; }
    }
}
