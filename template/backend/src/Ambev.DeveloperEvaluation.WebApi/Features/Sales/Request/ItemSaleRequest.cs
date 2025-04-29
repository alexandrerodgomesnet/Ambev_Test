using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Request;

public class ItemSaleRequest
{
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public ItemSale CreateItemSale() => ItemSale.Create(Title, Quantity, UnitPrice);
}