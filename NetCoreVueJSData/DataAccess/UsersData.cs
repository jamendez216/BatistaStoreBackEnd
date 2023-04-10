using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Models.Accesos.Usuarios;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSData.DataAccess
{
    public class UsersData : IUsersData
    {
        private readonly DBContextSys _context;
        public UsersData(DBContextSys context)
        {
            _context = context;
        }

        public async Task Create(CrearViewModel model, byte[] hash, byte[] salt)
        {
            var Usuario = new CUsuario()
            {
                idrol = model.idrol,
                nombre = model.nombre,
                tipo_documento = model.tipo_documento,
                email = model.email,
                num_documento = model.num_documento,
                direccion = model.direccion,
                telefono = model.telefono,
                password_hash = hash,
                password_salt = salt,
                condicion = true
            };
            _context.usuarios.Add(Usuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public bool EmailExists(string email)
        {
            return _context.usuarios.Any(x=>x.email == email);
        }

        public bool UserExists(int id)
        {
            return _context.usuarios.Any(e => e.idusuario == id);
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetAll()
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

        public async Task Edit()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task ToggleActivation(int id)
        {
            try
            {
                var usuario = await _context.usuarios.FirstOrDefaultAsync(x => x.idusuario == id);
                usuario.condicion = usuario.condicion ? false : true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CUsuario> Get(int id)
        {
            return await _context.usuarios.FirstOrDefaultAsync(x=> x.idusuario == id);
        }
    }
}
