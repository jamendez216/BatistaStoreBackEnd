using NetCoreVueJSModels.Models.Accesos.Usuarios;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UsuarioViewModel>> GetAll();
        Task Create(CrearViewModel model);
        Task ToggleActivation(int id);
        Task Edit(UpdateViewModel model);
    }
}
