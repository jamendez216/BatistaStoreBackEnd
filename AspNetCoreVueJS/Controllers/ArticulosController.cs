using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Models.Almacen.Articulo;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : BaseController
    {
        private readonly IProductService service;

        public ArticulosController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<ArticuloViewModel>> Get()
        {
            try
            {
                return await service.GetAll();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw;
            }
        }

        // GET: Categorias/Details/5

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var product = await service.Get(id.Value);
                    return Ok(product);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
            
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel cArticulo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.Create(cArticulo);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return HandleException(ex);
                }
                
            }
            return BadRequest();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Edit([FromBody] UpdateProductViewModel cArticulo)
        {
            if (!ModelState.IsValid || cArticulo.idarticulo <= 0)
            {
                return BadRequest();
            }
            try
            {
                await service.Edit(cArticulo);
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }

        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> ToggleActivation([FromRoute] int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }

            try
            {
                await service.ToggleActivation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }
    }
}