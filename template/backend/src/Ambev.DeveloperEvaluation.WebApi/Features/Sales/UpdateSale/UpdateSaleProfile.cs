using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.WebApi.Extensions;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public class UpdateSaleProfile: Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>()
            .ConvertUsing(source => source.ConvertUpdateSaleCommand());

        CreateMap<UpdateSaleResult, UpdateSaleResponse>()
            .ConvertUsing(source =>  source.ConvertUpdateSaleResponse());
    }
}