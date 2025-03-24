using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration: IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.NumberSale)
            .ValueGeneratedOnAdd();
        builder.Property(s => s.CreatedAt)
            .IsRequired();
        builder.Property(s => s.Customer)
            .IsRequired().HasMaxLength(50);
        builder.Property(s => s.TotalSaleValue)
            .IsRequired();
        builder.Property(s => s.BranchForSale)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(s => s.Products)
            .WithOne(i => i.Sale)
            .HasForeignKey(i => i.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.Status)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}