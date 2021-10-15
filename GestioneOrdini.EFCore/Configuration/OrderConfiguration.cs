using GestioneOrdini.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EFCore.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CodiceOrdine)
                .HasMaxLength(15)
                .IsRequired(false);

            builder
                .Property(c => c.DataOrdine)
                .IsRequired();

            builder
                .Property(c => c.CodiceProdotto)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(o => o.Importo)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .HasOne(o => o.Customer)
                .WithMany(c => c.Ordini)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
