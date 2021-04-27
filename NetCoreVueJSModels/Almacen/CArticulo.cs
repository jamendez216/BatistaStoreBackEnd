using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCoreVueJSModels.Almacen
{
    public class CArticulo
    {
        public int idarticulo { get; set; }
        [Required]
        public int idcategoria { get; set; }
        public string codigo { get; set; }
        [StringLength(60, ErrorMessage ="El nombre tiene un máximo de 60 caracteres")]
        public string nombre { get; set; }
        [Required]
        public double precio_venta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }
        
        public CCategoria Categoria { get; set; }
    }
}
