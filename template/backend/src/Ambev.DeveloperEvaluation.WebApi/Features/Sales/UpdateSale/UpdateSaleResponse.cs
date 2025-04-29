using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class UpdateSaleResponse : SaleResponse
{
    private UpdateSaleResponse(Guid id, string customer, string branchSale, DateTime createdAt,
        int numberSale, IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue)
        : base(id, numberSale, createdAt, customer, branchSale, products, status, totalSaleValue) { }

    private UpdateSaleResponse(Guid id, string customer, string branchSale,
        int numberSale, IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue)
        : base(id, numberSale, customer, branchSale, products, status, totalSaleValue) { }

    internal static UpdateSaleResponse Create(Guid id, string customer, string branchForSale, int numberSale,
        IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue, DateTime createdAt) =>
            new(id, customer, branchForSale, createdAt, numberSale, products, status, totalSaleValue);

    internal static UpdateSaleResponse Create(Guid id, string customer, string branchForSale, int numberSale,
        IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue) =>
            new(id, customer, branchForSale, numberSale, products, status, totalSaleValue);
}