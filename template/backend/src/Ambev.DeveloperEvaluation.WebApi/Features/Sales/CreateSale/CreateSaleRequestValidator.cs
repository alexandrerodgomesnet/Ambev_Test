using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CreateSale.Sales;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Customer: Required, length between 3 and 50 characters
    /// - TotalSaleValue: Cannot be None 0
    /// - BranchForSale: Required, length between 3 and 50 characters
    /// - Products: Cannot be Empty
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.Customer).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.TotalSaleValue).NotEqual(0);
        RuleFor(sale => sale.BranchForSale).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.Products).NotEmpty();
    }
}