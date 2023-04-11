using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.DataAccess
{
    public class ProductData : IProductData
    {

        private readonly DBContextSys _context;
        public ProductData(DBContextSys context)
        {
            _context = context;
        }

        public async Task Create(CArticulo cArticulo)
        {
            try
            {
                _context.Add(cArticulo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Edit(CArticulo cArticulo)
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CArticulo> Get(int id)
        {
            return await _context.articulos.FirstOrDefaultAsync(a => a.idarticulo == id);
        }

        public async Task<IEnumerable<ArticuloViewModel>> GetAll()
        {
            var categorias = await _context.articulos.Include(a => a.Categoria).ToListAsync();
            return categorias.Select(x => new ArticuloViewModel
            {
                idarticulo = x.idarticulo,
                idcategoria = x.idcategoria,
                categoria = x.Categoria.nombre,
                codigo = x.codigo,
                nombre = x.nombre,
                descripcion = x.descripcion,
                stock = x.stock,
                precio_venta = x.precio_venta,
                condicion = x.condicion

            }).OrderByDescending(x => x.condicion);
        }


        public bool CArticuloExists(int id)
        {
            return _context.articulos.Any(e => e.idarticulo == id);
        }

        public bool UserExists(int id)
        {
            return _context.articulos.Any(e => e.idarticulo == id);
        }

        public async Task ToggleActivation(int id)
        {
            try
            {
                var articulo = await _context.articulos.FirstOrDefaultAsync(x => x.idarticulo == id);
                articulo.condicion = articulo.condicion ? false : true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
