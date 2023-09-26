using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Sales;
using NetCoreVueJSModels.ViewModels.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Sales
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectData data;
        public SubjectService(ISubjectData data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<SubjectViewModel>> GetClients()
        {
            try
            {
                var subjects = await data.Get();
                return subjects.Where(y=>y.tipo_persona == "Client").Select(x => new SubjectViewModel()
                {
                    Id = x.idpersona,
                    SubjectType = x.tipo_persona,
                    DocumentType = x.tipo_documento,
                    DocumentNumber = x.num_documento,
                    Address = x.direccion,
                    Email= x.email,
                    Name = x.nombre,
                    Phone = x.telefono
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<SubjectViewModel>> GetProviders()
        {
            try
            {
                var subjects = await data.Get();
                return subjects.Where(y => y.tipo_persona == "Client").Select(x => new SubjectViewModel()
                {
                    Id = x.idpersona,
                    SubjectType = x.tipo_persona,
                    DocumentType = x.tipo_documento,
                    DocumentNumber = x.num_documento,
                    Address = x.direccion,
                    Email = x.email,
                    Name = x.nombre,
                    Phone = x.telefono
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(CreateSubjectViewModel model)
        {
            try
            {
                if (data.EmailExists(model.email))
                {
                    throw new Exception("Email already exists!");
                }

                var subject = new CPerson()
                {
                    direccion = model.direccion,
                    email= model.email,
                    nombre= model.nombre,
                    num_documento= model.num_documento,
                    telefono= model.telefono,
                    tipo_documento= model.tipo_documento,
                    tipo_persona= model.tipo_persona,
                };

                await data.Create(subject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(UpdateSubjectViewModel model)
        {
            try
            {
                var subject = await data.Get(model.id);
                if (subject == null)
                {
                    throw new Exception("User Not Found!");
                }

                subject.tipo_persona = model.SubjectType;
                subject.tipo_documento = model.DocumentType;
                subject.num_documento = model.DocumentNumber;
                subject.nombre = model.Name;
                subject.direccion = model.Address;
                subject.telefono = model.Phone;
                subject.email = model.Email;

                await data.Edit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
