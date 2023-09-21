using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Access
{
    public class RolService : IRolService
    {
        private readonly IRolData data;
        public RolService(IRolData data)
        {
            this.data= data;
        }
        public async Task<IEnumerable<RolViewModel>> Get()
        {
            var roles = await data.Get();
            return roles.Select(x => new RolViewModel()
            {
                idrol = x.idrol,
                condicion = x.condicion,
                descripcion = x.descripcion,
                nombre = x.nombre
            }).OrderByDescending(x => x.condicion);
        }

        public async Task<IEnumerable<SelectRolViewModel>> GetValList()
        {
            var roles = await data.Get();
            return roles.Select(x => new SelectRolViewModel
            {
                idrol = x.idrol,
                nombre = x.nombre

            }).OrderBy(x => x.nombre);
        }
    }
}
