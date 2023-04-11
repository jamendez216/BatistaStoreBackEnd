using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ArticuloViewModel>> GetAll();
        Task<CArticulo> Get(int id);
        Task Create(CreateProductViewModel cArticulo);
        Task Edit(UpdateProductViewModel cArticulo);
        Task ToggleActivation(int id);
    }
}
