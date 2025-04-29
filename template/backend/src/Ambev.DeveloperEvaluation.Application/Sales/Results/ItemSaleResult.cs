namespace Ambev.DeveloperEvaluation.Application.Sales.Results;

public class ItemSaleResult
{
    private ItemSaleResult(Guid id, string title, int quantity, decimal unitPrice, decimal discount, decimal totalItemValue)
    {
        Id = id;
        Title = title;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
        TotalItemValue = totalItemValue;
    }

    public static ItemSaleResult Create(Guid id, string title, int quantity, decimal unitPrice, decimal discount, decimal totalItemValue)
        => new(id, title, quantity, unitPrice, discount, totalItemValue);

    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    public decimal TotalItemValue { get; private set; }
}