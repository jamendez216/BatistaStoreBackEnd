using NetCoreVueJSModels.ViewModels.Ventas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectViewModel>> GetClients();
        Task<IEnumerable<SubjectViewModel>> GetProviders();
        Task Create(CreateSubjectViewModel viewModel);
        Task Edit(UpdateSubjectViewModel);
    }
}
