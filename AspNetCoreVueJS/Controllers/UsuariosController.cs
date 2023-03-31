using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVueJS.Models.Accesos.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Models.Accesos.Usuarios;

namespace AspNetCoreVueJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DBContextSys _context;

        public UsuariosController(DBContextSys context)
        {
            _context = context;
        }
        // GET: api/usuarios/get
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioViewModel>> Get()
        {
            var usuarios = await _context.usuarios.Include(a => a.rol).ToListAsync();
            return usuarios.Select(x => new UsuarioViewModel
            {
                idusuario = x.idusuario,
                idrol = x.idrol,
                rol = x.rol.nombre,
                nombre = x.nombre,
                direccion = x.direccion,
                email = x.email,
                telefono = x.telefono,
                tipo_documento = x.tipo_documento,
                num_documento = x.num_documento,
                password_hash = x.password_hash,
                condicion = x.condicion

            }).OrderByDescending(x => x.condicion);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CrearViewModel model)
        {
            if (ModelState.IsValid)
            {
                string Memail = model.email.ToLower();

                if (await _context.usuarios.AnyAsync(x=> x.email == Memail && x.condicion))
                {
                    return BadRequest("Email already exists!");
                }

                CreatePasswordHash(model.password, out byte[] passwordHash, out byte[] passwordSalt);
                var Usuario = new CUsuario()
                {
                   idrol = model.idrol,
                   nombre = model.nombre,
                   tipo_documento = model.tipo_documento,
                   email = Memail,
                   num_documento = model.num_documento,
                   direccion = model.direccion,
                   telefono = model.telefono,
                   password_hash = passwordHash,
                   password_salt = passwordSalt,
                   condicion = true
                };
                _context.usuarios.Add(Usuario);
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

        [HttpPut("[action]")]
        public async Task<IActionResult> Edit([FromBody] UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var usuario = await _context.usuarios.FirstOrDefaultAsync(x => x.idusuario == model.idusuario);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.idrol = model.idrol;
            usuario.nombre = model.nombre;
            usuario.direccion = model.direccion;
            usuario.telefono = model.telefono;
            usuario.email = model.email;

            if (model.act_password)
            {
                CreatePasswordHash(model.password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.password_hash = passwordHash;
                usuario.password_salt = passwordSalt;
            }
            

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

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> ToggleActivation([FromRoute] int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            var usuario = await _context.usuarios.FirstOrDefaultAsync(x => x.idusuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.condicion = usuario.condicion ? false : true;

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

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool CUsuarioExists(int id)
        {
            return _context.usuarios.Any(e => e.idusuario == id);
        }
    }
}