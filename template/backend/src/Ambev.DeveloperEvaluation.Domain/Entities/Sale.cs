using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int NumberSale { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal TotalSaleValue { get; set; }
    public string BranchForSale { get; set; } = string.Empty;
    public ProductList Products { get; set; }
    public SaleStatus Status { get; set; }

    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        Products = [];
        Status = SaleStatus.Unknown;
    }

    public void Cancelled() => Status = SaleStatus.Canceled;
    public void NotCancelled() => Status = SaleStatus.Active;

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