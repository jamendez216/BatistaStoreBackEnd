using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVueJSModels.Almacen;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSData.Mapping.Almacen
{
    public class ArticuloMap : IEntityTypeConfiguration<CArticulo>
    {
        public void Configure(EntityTypeBuilder<CArticulo> builder)
        {
            builder.ToTable("articulo")
                .HasKey(x=>x.idarticulo);
        }
    }
}
