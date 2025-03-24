namespace Ambev.DeveloperEvaluation.Application.Sales.Result;

public class ItemSaleResult
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalItemValue { get; set; }
}