using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>()
            .ConvertUsing(source => new CreateSaleCommand()
                {
                    Customer = source.Customer,
                    BranchForSale = source.BranchForSale,
                    Products = source.Products.Select(p => new ItemSale
                    {
                        Title = p.Title,
                        Quantity = p.Quantity,
                        UnitPrice = p.UnitPrice
                    }).ToList()
                });

        CreateMap<CreateSaleResult, CreateSaleResponse>()
            .ConvertUsing(source => new CreateSaleResponse()
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