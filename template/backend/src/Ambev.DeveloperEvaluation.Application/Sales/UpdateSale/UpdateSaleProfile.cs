using Ambev.DeveloperEvaluation.Application.Sales.Result;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>();
        CreateMap<Sale, UpdateSaleResult>()
            .ConvertUsing(source => new UpdateSaleResult()
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