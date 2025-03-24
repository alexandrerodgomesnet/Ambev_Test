using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

public class SaleResponse
{
    /// <summary>
    /// The unique identifier of the created sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale number
    /// </summary>
    public int NumberSale { get; set; }

    /// <summary>
    /// The sale CreatedAt
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The sale Customer
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// The sale Total Sale Value
    /// </summary>
    public decimal TotalSaleValue { get; set; }

    /// <summary>
    /// The sale Branch For Sale
    /// </summary>
    public string BranchForSale { get; set; } = string.Empty;

    /// <summary>
    /// The sale Products
    /// </summary>
    public IEnumerable<ItemSaleResponse> Products { get; set; } = [];

    /// <summary>
    /// The sale SaleStatus
    /// </summary>
    public SaleStatus Status { get; set; }
}