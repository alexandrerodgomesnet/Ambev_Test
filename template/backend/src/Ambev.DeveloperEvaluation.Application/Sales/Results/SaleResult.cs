using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.Results;

public class SaleResult
{
    public SaleResult(Guid id, int numberSale, DateTime createdAt, 
        string customer, decimal totalSaleValue, string branchForSale, 
        IEnumerable<ItemSaleResult> products, SaleStatus status)
    {
        Id = id;
        NumberSale = numberSale;
        CreatedAt = createdAt;
        Customer = customer;
        TotalSaleValue = totalSaleValue;
        BranchForSale = branchForSale;
        Products = products;
        Status = status;
    }

    public Guid Id { get; private set; }
    public int NumberSale { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string Customer { get; private set; } = string.Empty;
    public decimal TotalSaleValue { get; private set; }
    public string BranchForSale { get; private set; } = string.Empty;
    public IEnumerable<ItemSaleResult> Products { get; private set; } = [];
    public SaleStatus Status { get; private set; }
}