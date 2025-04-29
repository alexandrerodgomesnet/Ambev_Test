using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Response;

namespace Ambev.DeveloperEvaluation.WebApi.Extensions
{
    public static partial class ProfileExtensions
    {
        public static CreateSaleCommand ConvertCreateSaleCommand(this CreateSaleRequest sale) =>
            CreateSaleCommand.Create(sale.Customer, sale.BranchForSale, [.. sale.Products.Select(p => p.CreateItemSale())]);

        public static CreateSaleResponse ConvertCreateSaleResponse(this CreateSaleResult sale) =>
            CreateSaleResponse.Create(sale.Id, sale.Customer, sale.BranchForSale, sale.NumberSale,
                sale.Products.Select(p => ItemSaleResponse.Create(p.Id, p.Title, p.Quantity, p.UnitPrice, p.Discount, p.TotalItemValue)), sale.Status, sale.TotalSaleValue, sale.CreatedAt);

        public static UpdateSaleCommand ConvertUpdateSaleCommand(this UpdateSaleRequest sale) =>
            UpdateSaleCommand.Create(sale.Id, sale.Customer, sale.BranchForSale,
                [.. sale.Products.Select(p => ItemSale.Create(p.Id, p.Title, p.Quantity, p.UnitPrice))]);

        public static UpdateSaleResponse ConvertUpdateSaleResponse(this UpdateSaleResult sale) =>
            UpdateSaleResponse.Create(sale.Id, sale.Customer, sale.BranchForSale, sale.NumberSale,
                [.. sale.Products.Select(p => ItemSaleResponse.Create(p.Id, p.Title, p.Quantity, p.UnitPrice, p.Discount, p.TotalItemValue))],
                sale.Status, sale.TotalSaleValue, sale.CreatedAt);              

        public static GetSaleResponse ConvertGetSaleResult(this GetSaleResult sale) =>
            GetSaleResponse.Create(sale.Id, sale.Customer, sale.BranchForSale, sale.NumberSale,
                [.. sale.Products.Select(p => ItemSaleResponse.Create(p.Id, p.Title, p.Quantity, p.UnitPrice, p.Discount, p.TotalItemValue))],
                sale.Status,
                sale.TotalSaleValue,
                sale.CreatedAt);
    }
}
