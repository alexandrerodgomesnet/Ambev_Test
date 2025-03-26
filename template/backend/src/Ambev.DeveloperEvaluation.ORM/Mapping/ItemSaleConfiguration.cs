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
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Discount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.TotalItemValue)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(i => i.Sale)
            .WithMany(s => s.Products)
            .HasForeignKey(i => i.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}