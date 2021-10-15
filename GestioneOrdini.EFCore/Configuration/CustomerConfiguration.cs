using GestioneOrdini.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EFCore.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired(false);

            builder
                .Property(c => c.Cognome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.CodiceCliente)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .HasMany(c => c.Ordini)
                .WithOne(o => o.Customer);
        }
    }
}
