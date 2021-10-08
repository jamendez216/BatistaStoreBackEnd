using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCoreVueJSModels.Accesos
{
    public class CUsuario
    {
        public int idusuario { get; set; }
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
        public string email{ get; set; }
        [Required]
        public byte[] password_hash{ get; set; }
        [Required]
        public byte[] password_salt { get; set; }
        public bool condicion { get; set; }

        public CRol rol { get; set; }
    }

    public enum tipoDoc
    {
        Pasaporte,
        Cedula,
        NSS
    }
}
