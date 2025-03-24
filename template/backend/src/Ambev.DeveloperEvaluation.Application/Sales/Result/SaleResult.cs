using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.Result;

public class SaleResult
{
    public Guid Id { get; set; }
    public int NumberSale { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal TotalSaleValue { get; set; }
    public string BranchForSale { get; set; } = string.Empty;
    public IEnumerable<ItemSaleResult> Products { get; set; } = [];
    public SaleStatus Status { get; set; }
}