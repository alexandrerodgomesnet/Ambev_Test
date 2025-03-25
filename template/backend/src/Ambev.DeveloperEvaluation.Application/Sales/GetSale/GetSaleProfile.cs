using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.Result;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Profile for mapping between Sale entity and GetSaleResponse
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>()
        .ConvertUsing(source => new GetSaleResult()
                {
                    Id = source.Id,
                    Customer = source.Customer,
                    BranchForSale = source.BranchForSale,
                    Products = source.Products.Select(p => new ItemSaleResult
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Quantity = p.Quantity,
                        UnitPrice = p.UnitPrice,
                        Discount = p.Discount,
                        TotalItemValue = p.TotalItemValue
                    }).ToList(),
                    Status = source.Status,
                    TotalSaleValue = source.TotalSaleValue
                }
            );
    }
}