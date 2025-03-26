namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Request;

public class ItemSaleRequestWithId
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}