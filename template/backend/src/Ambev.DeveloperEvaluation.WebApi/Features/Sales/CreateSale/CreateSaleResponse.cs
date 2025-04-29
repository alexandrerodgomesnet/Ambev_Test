using Ambev.DeveloperEvaluation.Application.Sales.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class CreateSaleResponse : SaleResponse
{
    private CreateSaleResponse(Guid id, string customer, string branchSale, DateTime createdAt,
        int numberSale, IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue)
        : base(id, numberSale, createdAt, customer, branchSale, products, status, totalSaleValue) { }

    internal static CreateSaleResponse Create(Guid id, string customer, string branchForSale, int numberSale,
        IEnumerable<ItemSaleResponse> products, SaleStatus status, decimal totalSaleValue, DateTime createdAt) => 
            new(id, customer, branchForSale, createdAt, numberSale, products, status, totalSaleValue);
}