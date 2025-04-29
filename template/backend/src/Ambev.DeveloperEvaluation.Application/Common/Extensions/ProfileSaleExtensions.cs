using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Common.Extensions
{
    public static partial class ProfileExtensions
    {
        public static CreateSaleResult ConvertCreateSaleResult(this Sale sale) =>
            CreateSaleResult.Create(sale.Id, sale.Customer, sale.BranchForSale, sale.NumberSale,
                sale.Products, sale.Status, sale.TotalSaleValue);
        public static UpdateSaleResult ConvertUpdateSaleResult(this Sale sale) =>
            UpdateSaleResult.Create(sale.Id, sale.Customer, sale.BranchForSale,
            sale.Products, sale.Status, sale.TotalSaleValue);

        public static GetSaleResult ConvertGetSaleResult(this Sale sale) =>
            GetSaleResult.Create(sale.Id, sale.Customer, sale.BranchForSale,
            sale.Products, sale.Status, sale.TotalSaleValue);
    }
}
