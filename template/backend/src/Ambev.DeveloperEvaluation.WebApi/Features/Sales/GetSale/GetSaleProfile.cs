using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Profile for mapping GetSale feature requests to commands
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale feature
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Guid, GetSaleCommand>()
            .ConstructUsing(id => new GetSaleCommand(id));

        CreateMap<GetSaleResult, GetSaleResponse>()
            .ConvertUsing(source => new GetSaleResponse()
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
