namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

public class ItemSaleResponse
{
    /// <summary>
    /// The unique identifier of the created sale
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// The ItemSale Title
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// The ItemSale Quantity
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// The ItemSale UnitPrice
    /// </summary>
    public decimal UnitPrice { get; set; }
    /// <summary>
    /// The ItemSale Discount
    /// </summary>
    public decimal Discount { get; set; }
    /// <summary>
    /// The ItemSale TotalItemValue
    /// </summary>
    public decimal TotalItemValue { get; set; }
}