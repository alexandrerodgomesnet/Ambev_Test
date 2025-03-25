using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ItemSaleConfiguration: IEntityTypeConfiguration<ItemSale>
{
    public void Configure(EntityTypeBuilder<ItemSale> builder)
    {
        builder.ToTable("ItemSales");

        builder.HasKey(s => s.Id);

        builder.Property(i => i.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Quantity)
            .IsRequired();

        builder.Property(s => s.UnitPrice)
            .HasColumnType("decimal")
            .IsRequired();

        builder.Property(s => s.Discount)
            .HasColumnType("decimal")
            .IsRequired();

        builder.Property(s => s.TotalItemValue)
            .HasColumnType("decimal")
            .IsRequired();

        builder.Property(s => s.Status)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}