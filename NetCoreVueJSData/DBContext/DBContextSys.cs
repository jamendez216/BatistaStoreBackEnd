using Microsoft.EntityFrameworkCore;
using NetCoreVueJSData.Mapping;
using NetCoreVueJSData.Mapping.Accesos;
using NetCoreVueJSData.Mapping.Almacen;
using NetCoreVueJSModels.Accesos;
using NetCoreVueJSModels.Almacen;
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
        public DbSet<CRol> roles{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new RolMap());
        }

    }
}
