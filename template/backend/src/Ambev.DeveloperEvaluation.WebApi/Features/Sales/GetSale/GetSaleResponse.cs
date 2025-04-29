using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse : SaleResponse 
{
    public GetSaleResponse(Guid id) : base(id)
    {
    }

    private GetSaleResponse(Guid id, string customer, string branchSale, DateTime createdAt,
        int numberSale, IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue)
        : base(id, numberSale, createdAt, customer, branchSale, products, status, totalSaleValue) { }

    internal static GetSaleResponse Create(Guid id, string customer, string branchForSale, int numberSale,
        IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue, DateTime createdAt) =>
            new(id, customer, branchForSale, createdAt, numberSale, products, status, totalSaleValue);
}