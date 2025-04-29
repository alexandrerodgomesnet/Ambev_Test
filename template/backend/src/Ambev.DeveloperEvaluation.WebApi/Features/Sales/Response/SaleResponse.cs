using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

public class SaleResponse
{
    private SaleResponse() { }
    public SaleResponse(Guid id) { Id = id; }

    public SaleResponse(Guid id, int numberSale, string customer, string branchSale,
        IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue) : this(id)
    {
        NumberSale = numberSale;
        Customer = customer;
        BranchForSale = branchSale;
        Products = products;
        Status = status;
        TotalSaleValue = totalSaleValue;
    }

    public SaleResponse(Guid id, int numberSale, DateTime createdAt, string customer, string branchSale, 
        IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue) : this(id, numberSale, customer,
            branchSale, products, status, totalSaleValue)
    {
        CreatedAt = createdAt;
    }
    
    public Guid Id { get; set; }
    public int NumberSale { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal TotalSaleValue { get; set; }
    public string BranchForSale { get; set; } = string.Empty;
    public IEnumerable<ItemSaleResponse> Products { get; set; } = [];
    public SaleStatus Status { get; set; }
}