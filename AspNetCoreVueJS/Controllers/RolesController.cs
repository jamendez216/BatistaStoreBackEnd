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
using NetCoreVueJSModels.Models.Usuarios;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolService service;

        public RolesController(IRolService service)
        {
            this.service = service;
        }

        // GET: api/Roles/Get
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Get()
        {
            return await service.Get();

        }

        // Summary:
        //      Get a value List for all roles that are enabled at the moment
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectRolViewModel>> GetValList()
        {
            return await service.GetValList();
        }

    }
}