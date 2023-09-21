using NetCoreVueJSModels.Accesos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.Interface
{
    public interface IRolData
    {
        Task<List<CRol>> Get(bool isValList = false);
    }
}
