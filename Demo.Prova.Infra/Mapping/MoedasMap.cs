using Demo.Prova.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Prova.Infra.Mapping
{
    public class MoedasMap : IEntityTypeConfiguration<Moedas>
    {
        public void Configure(EntityTypeBuilder<Moedas> builder)
        {
            builder.ToTable("Moeda");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Moeda)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Moeda")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Data_Inicio)
               .HasConversion(prop => prop.Date, prop => prop)
               .IsRequired()
               .HasColumnName("Data_Inicio")
               .HasColumnType("DateTime");

            builder.Property(prop => prop.Data_Fim)
                .HasConversion(prop => prop.Date, prop => prop)
                .IsRequired()
                .HasColumnName("Data_Fim")
                .HasColumnType("DateTime");
        }
    }
}
