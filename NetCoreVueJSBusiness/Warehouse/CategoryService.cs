using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Categoria;
using NetCoreVueJSModels.ViewModels.Almacen.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Warehouse
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryData data;
        public CategoryService(ICategoryData data)
        {
            this.data = data;
        }

        public async Task Create(CrearViewModel cCategoria)
        {
            var categoria = new CCategoria()
            {
                nombre = cCategoria.nombre,
                descripcion = cCategoria.descripcion,
                condicion = true
            };
            await data.Create(categoria);
        }

        public async Task Delete(int id)
        {
            try
            {
                var category = await data.Get(id);
                await data.Delete(category);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Edit(ActualizarViewModel cCategoria)
        {
            try
            {
                var category = await data.Get(cCategoria.idcategoria);

                category.nombre = cCategoria.nombre;
                category.descripcion = cCategoria.descripcion;

                await data.Edit(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CategoriaViewModel>> Get()
        {
            try
            {
                var categories = await data.Get();
                return categories.Select(x => new CategoriaViewModel
                {
                    CategoriaID = x.idcategoria,
                    Nombre = x.nombre,
                    Descripcion = x.descripcion,
                    Condicion = x.condicion
                }).OrderByDescending(x => x.Condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaViewModel> Get(int? id)
        {
            try
            {
                var category = await data.Get(id);
                return new CategoriaViewModel()
                {
                    CategoriaID = category.idcategoria,
                    Nombre = category.nombre,
                    Descripcion = category.descripcion,
                    Condicion = category.condicion
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CategoryValueListModel>> GetValList()
        {
            try
            {
                var categories = await data.Get();
                return categories.Select(x => new CategoryValueListModel
                {
                    id = x.idcategoria,
                    name = x.nombre,
                }).OrderByDescending(x => x.name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ToggleActivation(int id)
        {
            var category = await data.Get(id);
            category.condicion = category.condicion ? false : true;
            await data.ToggleActivation(category);
        }

        public async Task<bool> CategoryExists(int id)
        {
            try
            {
                return await data.CategoryExists(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
