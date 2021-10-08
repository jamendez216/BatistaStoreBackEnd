using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVueJSModels.Accesos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSData.Mapping.Accesos
{
    public class RolMap : IEntityTypeConfiguration<CRol>
    {
        public void Configure(EntityTypeBuilder<CRol> builder)
        {
            builder.ToTable("rol")
                .HasKey(x => x.idrol);
        }

    }
}
