using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Categoria;
using NetCoreVueJSModels.ViewModels.Almacen.Categoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoriaViewModel>> Get();
        Task<IEnumerable<CategoryValueListModel>> GetValList();
        Task<CategoriaViewModel> Get(int? id);
        Task Create(CrearViewModel cCategoria);
        Task Edit(ActualizarViewModel cCategoria);
        Task Delete(int id);
        Task ToggleActivation(int id);
        Task<bool> CategoryExists(int id);
    }
}
