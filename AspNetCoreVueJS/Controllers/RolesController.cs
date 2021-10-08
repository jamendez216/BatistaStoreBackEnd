using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVueJS.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSModels.Accesos;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DBContextSys _context;

        public RolesController(DBContextSys context)
        {
            _context = context;
        }

        // GET: api/Roles/Get
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Get()
        {
            var rolees = await _context.roles.ToListAsync();
            return rolees.Select(x => new RolViewModel
            {
                idrol = x.idrol,
                condicion = x.condicion,
                descripcion = x.descripcion,
                nombre = x.nombre
            }).OrderByDescending(x => x.condicion);
        }

        // Summary:
        //      Get a value List for all roles that are enabled at the moment
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectRolViewModel>> GetValList()
        {
            var roles = await _context.roles.Where(x => x.condicion).ToListAsync();
            var res = roles.Select( x=>  new SelectRolViewModel
            {
                idrol = x.idrol,
                nombre = x.nombre

            }).OrderBy(x => x.nombre);
            return res;
        }


        private bool CRolExists(int id)
        {
            return _context.roles.Any(e => e.idrol == id);
        }
    }
}