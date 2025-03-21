using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemSale
{
    public string Title { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; private set; }
    public decimal TotalItemValue { get; private set; }

    public void SetDiscount(decimal discount) => Discount = discount / 100;

    public ValidationResultDetail Validate()
    {
        var validator = new ItemSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    public void SetTotalItemValue(decimal value) => TotalItemValue = value;
}