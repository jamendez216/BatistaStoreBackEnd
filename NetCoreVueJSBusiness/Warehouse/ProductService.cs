using Microsoft.EntityFrameworkCore;
using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Warehouse
{
    public class ProductService : IProductService
    {
        private readonly IProductData data;
        public ProductService(IProductData data)
        {
            this.data = data;
        }

        public async Task Create(CreateProductViewModel cArticulo)
        {
            try
            {
                var Articulo = new CArticulo()
                {
                    idcategoria = cArticulo.idcategoria,
                    codigo = cArticulo.codigo,
                    nombre = cArticulo.nombre,
                    descripcion = cArticulo.descripcion,
                    condicion = true,
                    precio_venta = cArticulo.precio_venta,
                    stock = cArticulo.stock
                };
                await data.Create(Articulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task ToggleActivation(int id)
        {
            try
            {
                if (!data.CArticuloExists(id))
                {
                    throw new Exception("Product Not Found!");
                }
                await data.ToggleActivation(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Edit(UpdateProductViewModel cArticulo)
        {
            try
            {
                var articulo = await data.Get(cArticulo.idarticulo);

                if (articulo == null)
                {
                    throw new Exception("Product Not Found!");
                }
                articulo.idcategoria = cArticulo.idcategoria;
                articulo.codigo = cArticulo.codigo;
                articulo.nombre = cArticulo.nombre;
                articulo.precio_venta = cArticulo.precio_venta;
                articulo.stock = cArticulo.stock;
                articulo.descripcion = cArticulo.descripcion;
                await data.Edit(articulo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<CArticulo> Get(int id)
        {
            try
            {
                var product = await data.Get(id);
                if (product == null)
                    throw new Exception("Product Not Found!");
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ArticuloViewModel>> GetAll()
        {
            try
            {
                return await data.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
