using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.WebApi.Extensions;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Guid, GetSaleQuery>()
            .ConstructUsing(id => new GetSaleQuery(id));

        CreateMap<GetSaleResult, GetSaleResponse>()
            .ConvertUsing(source => source.ConvertGetSaleResult());
    }
}
