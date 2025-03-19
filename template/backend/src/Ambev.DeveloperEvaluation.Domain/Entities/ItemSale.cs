namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemSale
{
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; private set; }
    public decimal TotalItemValue => UnitPrice * Quantity;
}