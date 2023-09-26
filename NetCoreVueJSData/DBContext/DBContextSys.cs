using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.Mapping;
using NetCoreVueJSData.Mapping.Accesos;
using NetCoreVueJSData.Mapping.Almacen;
using NetCoreVueJSData.Mapping.Sales;
using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSData.DBContext
{
    public class DBContextSys : DbContext
    {
        public DBContextSys(DbContextOptions<DBContextSys> options) : base(options)
        {

        }
        public DbSet<CCategoria> categorias { get; set; }
        public DbSet<CArticulo> articulos { get; set; }
        public DbSet<CRol> roles { get; set; }
        public DbSet<CUsuario> usuarios { get; set; }
        public DbSet<CPerson> personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
        }

    }
}
