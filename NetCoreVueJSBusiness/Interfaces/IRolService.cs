using NetCoreVueJSModels.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<RolViewModel>> Get();
        Task<IEnumerable<SelectRolViewModel>> GetValList();
    }
}
