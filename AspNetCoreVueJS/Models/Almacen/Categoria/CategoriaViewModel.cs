using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVueJS.Models.Almacen.Categoria
{
    public class CategoriaViewModel
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public bool Condicion{ get; set; }
    }
}
