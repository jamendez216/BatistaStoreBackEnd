using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Models.Accesos.Usuarios;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.Interface
{
    public interface IUsersData
    {
        Task<IEnumerable<UsuarioViewModel>> GetAll();
        Task Create(CrearViewModel model, byte[] hash, byte[] salt);
        bool UserExists(int id);
        bool EmailExists(string email);
        Task ToggleActivation(int id);
        Task Edit();
        Task<CUsuario> Get(int id);
    }
}
