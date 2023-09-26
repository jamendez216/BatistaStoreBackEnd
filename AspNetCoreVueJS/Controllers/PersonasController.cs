using Microsoft.AspNetCore.Mvc;
using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSModels.ViewModels.Ventas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : BaseController
    {
        private readonly ISubjectService service;
        public PersonasController(ISubjectService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectViewModel>> GetClients()
        {
            try
            {
                return await service.GetClients();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw;
            }
        }
        [HttpGet]
        public async Task<IEnumerable<SubjectViewModel>> GetProviders()
        {
            try 
            {
            return await service.GetProviders();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubjectViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await service.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw;
            }
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> Edit([FromBody] UpdateSubjectViewModel model)
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

    }
}
