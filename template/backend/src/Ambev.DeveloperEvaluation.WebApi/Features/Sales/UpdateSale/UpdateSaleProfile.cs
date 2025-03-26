using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class UpdateSaleProfile: Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>()
            .ConvertUsing(source => new (source.Id, source.Customer,
                source.BranchForSale, 
                source.Products.Select(p => new ItemSale
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Quantity = p.Quantity,
                        UnitPrice = p.UnitPrice
                    }).ToList())
                );

        CreateMap<UpdateSaleResult, UpdateSaleResponse>()
            .ConvertUsing(source => new UpdateSaleResponse()
                {
                    Id = source.Id,
                    Customer = source.Customer,
                    BranchForSale = source.BranchForSale,
                    Products = source.Products.Select(p => new ItemSaleResponse
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