using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.Interface
{
    public interface IProductData
    {
        Task<IEnumerable<ArticuloViewModel>> GetAll();
        Task<CArticulo> Get(int id);
        Task Create(CArticulo cArticulo);
        Task Edit(CArticulo cArticulo);
        bool CArticuloExists(int id);
        Task ToggleActivation(int id);
    }
}
