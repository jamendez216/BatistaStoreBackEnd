using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVueJSModels.Accesos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSData.Mapping.Accesos
{
    public class UsuarioMap : IEntityTypeConfiguration<CUsuario>
    {
        public void Configure(EntityTypeBuilder<CUsuario> builder)
        {
            builder.ToTable("usuario")
                .HasKey(x => x.idusuario);
        }

    }
}
