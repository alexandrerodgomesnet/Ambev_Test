using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Common.Extensions;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<Sale, CreateSaleResult>()
            //.ConvertUsing(source => CreateSaleResult.Create(source.Id, source.Customer, source.BranchForSale,
            //    source.Products, source.Status, source.TotalSaleValue)
            //);
            .ConvertUsing(source => source.ConvertCreateSaleResult());
    }
}