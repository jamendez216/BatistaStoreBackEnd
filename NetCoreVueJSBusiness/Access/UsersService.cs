using Microsoft.EntityFrameworkCore;
using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSData.Interface;
using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Models.Accesos.Usuarios;
using NetCoreVueJSModels.Models.Almacen.Articulo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreVueJSBusiness.Access
{
    public class UsersService : IUsersService
    {
        private readonly IUsersData data; 
        public UsersService(IUsersData data) 
        {
            this.data = data;
        }

        public async Task Create(CrearViewModel model)
        {
            try
            {
                if (data.EmailExists(model.email))
                {
                    throw new Exception("Email already exists!");
                }

                var password = CreatePasswordHash(model.password);

                await data.Create(model, password.hash, password.salt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(UpdateViewModel model)
        {
            try
            {
                var user = await data.Get(model.idusuario);
                if (user == null)
                {
                    throw new Exception("User Not Found!");
                }

                if (model.act_password)
                {
                    var password = CreatePasswordHash(model.password);
                    user.password_hash = password.hash;
                    user.password_salt = password.salt;
                }
                user.idrol = model.idrol;
                user.nombre = model.nombre;
                user.direccion = model.direccion;
                user.telefono = model.telefono;
                user.email = model.email;

                await data.Edit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<IEnumerable<UsuarioViewModel>> GetAll()
        {
            return data.GetAll();
        }

        public async Task ToggleActivation(int id)
        {
            try
            {
                if (!data.UserExists(id))
                {
                    throw new Exception("User Not Found");
                }
                await data.ToggleActivation(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            byte[] passwordSalt, passwordHash;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (passwordHash, passwordSalt);
        }

    }
}
