using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemSale : BaseEntity
{
    public ItemSale(string title, int quantity, decimal unitPrice)
    {
        Title = title;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Status = ItemSaleStatus.Active;
    }
    public ItemSale(Guid id, string title, int quantity, decimal unitPrice) : this(title, quantity, quantity)
    {
        Id = id;
    }


    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalItemValue { get; set; }
    public ItemSaleStatus Status { get; set; }

    public Guid SaleId { get; set; }
    public Sale? Sale { get; set; }

    public static ItemSale Create(string title, int quantity, decimal unitPrice) =>
        new(title, quantity, unitPrice);
    public static ItemSale Create(Guid id, string title, int quantity, decimal unitPrice) =>
        new(id, title, quantity, unitPrice);

    public void SetDiscount(decimal discount) => Discount = discount / 100;
    public void SetTotalItemValue(decimal value) => TotalItemValue = value;
}