using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for user creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - NumberSale: Cannot be 0
    /// - CreatedAt: Required
    /// - Customer: Required, length between 3 and 50 characters
    /// - TotalSaleValue: Cannot be 0
    /// - BranchForSale: Required, length between 3 and 50 characters
    /// - Products: Required
    /// - Status: Cannot be set to Unknown
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.NumberSale).NotEqual(0);
        RuleFor(sale => sale.CreatedAt).NotEmpty();
        RuleFor(sale => sale.Customer).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.TotalSaleValue).NotEqual(0);
        RuleFor(sale => sale.BranchForSale).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.Products).NotEmpty();
    }
}