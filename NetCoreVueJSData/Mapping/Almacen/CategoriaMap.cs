using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVueJSModels.Almacen;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSData.Mapping.Almacen
{
    public class CategoriaMap : IEntityTypeConfiguration<CCategoria>
    {
        public void Configure(EntityTypeBuilder<CCategoria> builder)
        {
            builder.ToTable("categoria")
                .HasKey(x => x.idcategoria);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
            builder.Property(c => c.nombre)
                .IsRequired();
        }
    }
}
