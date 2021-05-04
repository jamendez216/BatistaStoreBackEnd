using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVueJS.Models.Almacen.Articulo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSModels.Almacen;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly DBContextSys _context;

        public ArticulosController(DBContextSys context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<ArticuloViewModel>> Get()
        {
            var categorias = await _context.articulos.Include(a=>a.Categoria).ToListAsync();
            return categorias.Select(x => new ArticuloViewModel
            {
                idarticulo = x.idarticulo,
                idcategoria = x.idcategoria,
                categoria = x.Categoria.descripcion,
                codigo = x.codigo,
                nombre = x.nombre,
                descripcion = x.descripcion,
                stock = x.stock,
                precio_venta = x.precio_venta,
                condicion = x.condicion

            }).OrderByDescending(x => x.condicion);
        }

        // GET: Categorias/Details/5

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var articulo = await _context.articulos.Include(a=>a.Categoria)
                .SingleOrDefaultAsync(x=>x.idarticulo == id);

            if (articulo == null)
            {
                return NotFound();
            }
            return Ok(new ArticuloViewModel() {
                idarticulo = articulo.idarticulo,
                idcategoria = articulo.idcategoria,
                categoria = articulo.Categoria.descripcion,
                codigo = articulo.codigo,
                nombre = articulo.nombre,
                descripcion = articulo.descripcion,
                stock = articulo.stock,
                precio_venta = articulo.precio_venta,
                condicion = articulo.condicion
            });
        }



        private bool CArticuloExists(int id)
        {
            return _context.articulos.Any(e => e.idarticulo == id);
        }
    }
}