using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Categoria;
using NetCoreVueJSModels.ViewModels.Almacen.Categoria;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly DBContextSys _context;
        private readonly ICategoryService service;

        public CategoriasController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaViewModel>> Get()
        {
            return await service.Get();
            
        }

        // Summary:
        //      Get a value List for all categories that are enabled at the moment
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoryValueListModel>> GetValList()
        {
            return await service.GetValList();
        }

        // GET: Categorias/Details/5

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var categoria = await service.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CrearViewModel cCategoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.Create(cCategoria);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
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
            var categoryExists = await service.CategoryExists(cCategoria.idcategoria);
            if (!categoryExists)
            {
                return NotFound();
            }
            service.Edit(cCategoria);

            return Ok();
        }


        // POST: Categorias/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var categoryExists = await service.CategoryExists(id);
                if (!categoryExists)
                {
                    return NotFound();
                }
                await service.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> ToggleActivation([FromRoute] int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }

            var categoryExists = await service.CategoryExists(id);
            if (!categoryExists)
            {
                return NotFound();
            }
            await service.ToggleActivation(id);

            return Ok();
        }

    }
}
