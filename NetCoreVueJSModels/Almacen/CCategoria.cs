using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace NetCoreVueJSModels.Almacen
{
    public class CCategoria
    {
        public int idcategoria { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "This property has a max length of 50 and a minimum of 3")]
        public string nombre { get; set; }
        [MaxLength(256)]
        public string descripcion { get; set; }
        public bool condicion { get; set; }
    }

}
