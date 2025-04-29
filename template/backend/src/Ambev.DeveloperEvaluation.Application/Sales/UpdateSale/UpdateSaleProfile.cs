using Ambev.DeveloperEvaluation.Application.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>();
        CreateMap<Sale, UpdateSaleResult>()
        .ConvertUsing(source => source.ConvertUpdateSaleResult());
    }
}