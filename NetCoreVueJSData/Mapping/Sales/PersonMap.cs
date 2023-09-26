using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVueJSModels.Almacen;
using NetCoreVueJSModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreVueJSData.Mapping.Sales
{
    public class PersonMap : IEntityTypeConfiguration<CPerson>
    {
        public void Configure(EntityTypeBuilder<CPerson> builder)
        {
            builder.ToTable("persona")
                .HasKey(p=> p.idpersona);
        }
    }
}
