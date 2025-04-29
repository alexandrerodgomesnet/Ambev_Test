namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

public class ItemSaleResponse
{
    private ItemSaleResponse(Guid id, string title, int quantity, decimal unitPrice, decimal discount, decimal totalItemValue)
    {
        Id = id;
        Title = title;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
        TotalItemValue = totalItemValue;
    }

    public static ItemSaleResponse Create(Guid id, string title, int quantity, decimal unitPrice, decimal discount, decimal totalItemValue) =>
        new(id, title, quantity, unitPrice, discount, totalItemValue);

    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalItemValue { get; set; }
    
}