using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Categoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.Interface
{
    public interface ICategoryData
    {
        Task<List<CCategoria>> Get();
        Task<CCategoria> Get(int? id);
        Task Create(CCategoria category);
        Task<bool> CategoryExists(int id);
        Task Edit(CCategoria cCategoria);
        Task Delete(CCategoria category);
        Task ToggleActivation(CCategoria id);
    }
}
