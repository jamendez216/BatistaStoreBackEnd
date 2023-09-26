using NetCoreVueJSModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.Interface
{
    public interface ISubjectData
    {
        Task<IEnumerable<CPerson>> Get();
        bool EmailExists(string email);
        Task ToggleActivation(int id);
        Task Edit();
        Task Create(CPerson model);
        Task<CPerson> Get(int id);
    }
}
