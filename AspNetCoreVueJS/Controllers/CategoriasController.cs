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
            });
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

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idcategoria,Name,Description,Condition")] CCategoria cCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCategoria);
                await _context.SaveChangesAsync();
                return null;
            }
            return View(cCategoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCategoria = await _context.categorias.FindAsync(id);
            if (cCategoria == null)
            {
                return NotFound();
            }
            return View(cCategoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idcategoria,Name,Description,Condition")] CCategoria cCategoria)
        {
            if (id != cCategoria.idcategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CCategoriaExists(cCategoria.idcategoria))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return null;
            }
            return View(cCategoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCategoria = await _context.categorias
                .FirstOrDefaultAsync(m => m.idcategoria == id);
            if (cCategoria == null)
            {
                return NotFound();
            }

            return View(cCategoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cCategoria = await _context.categorias.FindAsync(id);
            _context.categorias.Remove(cCategoria);
            await _context.SaveChangesAsync();
            return null;
        }

        private bool CCategoriaExists(int id)
        {
            return _context.categorias.Any(e => e.idcategoria == id);
        }
    }
}
