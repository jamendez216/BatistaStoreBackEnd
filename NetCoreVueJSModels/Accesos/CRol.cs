using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace NetCoreVueJSModels.Accesos
{
    public class CRol
    {
        public int idrol { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage ="Name must be between 3 and 30 characters")]
        public string nombre { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description value must be between 3 and 100 characters")]
        public string descripcion { get; set; }
        public bool condicion { get; set; }
        [JsonIgnore]
        public ICollection<CUsuario> usuarios { get; set; }
    }
}
