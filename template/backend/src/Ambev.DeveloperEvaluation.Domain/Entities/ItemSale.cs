using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemSale : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalItemValue { get; set; }

    public Guid SaleId { get; set; }
    public Sale? Sale { get; set; }

    public void SetDiscount(decimal discount) => Discount = discount / 100;
    public void SetTotalItemValue(decimal value) => TotalItemValue = value;
}