using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Common.Extensions;

namespace Ambev.DeveloperEvaluation.Application.Sales;
public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>()
        .ConvertUsing(source => source.ConvertGetSaleResult());
    }
}