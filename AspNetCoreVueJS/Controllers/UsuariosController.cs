using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Models.Accesos.Usuarios;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : BaseController
    {
        private readonly IUsersService service;

        public UsuariosController(IUsersService service)
        {
            this.service = service;
        }
        // GET: api/usuarios/get
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioViewModel>> Get()
        {
            return await service.GetAll();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CrearViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Create(model);
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
        public async Task<IActionResult> Edit([FromBody] UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await service.Edit(model);
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
                service.ToggleActivation(id);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            return Ok();
        }

    }
}