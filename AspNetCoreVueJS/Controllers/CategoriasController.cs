using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVueJS.Models.Almacen.Categoria;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSModels.Almacen;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly DBContextSys _context;

        public CategoriasController(DBContextSys context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaViewModel>> Get()
        {
            var categorias = await _context.categorias.ToListAsync();
            return categorias.Select(x => new CategoriaViewModel
            {
                CategoriaID = x.idcategoria,
                Nombre = x.nombre,
                Descripcion = x.descripcion,
                Condicion = x.condicion
            }).OrderByDescending(x=>x.Condicion);
        }

        // GET: Categorias/Details/5

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var categorias = await _context.categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }
            return Ok(new CategoriaViewModel() { CategoriaID = categorias.idcategoria, Nombre = categorias.nombre, Descripcion = categorias.descripcion, Condicion = categorias.condicion});
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CrearViewModel cCategoria)
        {
            if (ModelState.IsValid)
            {
                var categoria = new CCategoria()
                {
                    nombre = cCategoria.nombre,
                    descripcion = cCategoria.descripcion,
                    condicion = true
                };
                _context.Add(categoria);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception es)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return BadRequest();
        }

        // POST: Categorias/Edit/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit([FromBody]ActualizarViewModel cCategoria)
        {
            if (!ModelState.IsValid || cCategoria.idcategoria <= 0)
            {
                return BadRequest();
            }
            var categoria = await _context.categorias.FirstOrDefaultAsync(x=>x.idcategoria == cCategoria.idcategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = cCategoria.nombre;
            categoria.descripcion = cCategoria.descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }


        // POST: Categorias/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var categoria = await _context.categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.categorias.Remove(categoria);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> ToggleActivation([FromRoute] int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            var categoria = await _context.categorias.FirstOrDefaultAsync(x => x.idcategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = categoria.condicion ?  false : true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

        private bool CCategoriaExists(int id)
        {
            return _context.categorias.Any(e => e.idcategoria == id);
        }
    }
}
