using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int NumberSale { get; set; }
    public DateTime CreatedAt { get; set; }
    public Customer? Customer { get; set; }
    public decimal TotalSaleValue { get; set; }
    public Branch? BranchForSale { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalItemValue { get; set; }
    public int Quantity { get; set; }
    public SaleStatus Status { get; set; }

    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        Products = [];
    }

    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}