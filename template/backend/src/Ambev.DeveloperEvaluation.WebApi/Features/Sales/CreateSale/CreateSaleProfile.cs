using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.WebApi.Extensions;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>()
            .ConvertUsing(source => source.ConvertCreateSaleCommand());

        CreateMap<CreateSaleResult, CreateSaleResponse>()
            .ConvertUsing(source => source.ConvertCreateSaleResponse());
    }
}