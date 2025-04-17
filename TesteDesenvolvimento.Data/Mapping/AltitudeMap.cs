using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvimento.Dominio.Dominio;

namespace TesteDesenvolvimento.Data.Mapping
{
    public class AltitudeMap : IEntityTypeConfiguration<Altitude>
    {
        public void Configure(EntityTypeBuilder<Altitude> builder)
        {
            builder.ToTable("tb_Altitude");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Latitude)
               .IsRequired()
               .HasColumnType("decimal(10,5)");

            builder.Property(a => a.Longitude)
               .IsRequired()
               .HasColumnType("decimal(10,5)");

            builder.Property(a => a.Radius)
              .IsRequired()
              .HasColumnType("int");
        }
    }
}
