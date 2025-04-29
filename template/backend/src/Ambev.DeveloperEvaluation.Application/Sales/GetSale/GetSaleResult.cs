using Ambev.DeveloperEvaluation.Application.Sales.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class GetSaleResult : SaleResult 
{
    private GetSaleResult(Guid id, int numberSale, DateTime createdAt, string customer,
        string branchSale, IEnumerable<ItemSaleResult> products, SaleStatus status, decimal totalSaleValue)
        : base(id, numberSale, createdAt, customer, totalSaleValue, branchSale, products, status)
    { }

    public static GetSaleResult Create(Guid id, string customer, string branchSale, IEnumerable<ItemSale> products,
        SaleStatus status, decimal totalSaleValue) =>
        new(id, 0, DateTime.UtcNow, customer, branchSale,
            [.. products.Select(p => ItemSaleResult.Create(p.Id, p.Title, p.Quantity, p.UnitPrice, p.Discount, p.TotalItemValue))],
            status, totalSaleValue);
}
