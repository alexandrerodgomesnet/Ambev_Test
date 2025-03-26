using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales;

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
    /// - CreatedAt: Required
    /// - Customer: Required, length between 3 and 50 characters
    /// - TotalSaleValue: Cannot be 0
    /// - BranchForSale: Required, length between 3 and 50 characters
    /// - Products: Required
    /// - Status: Cannot be set to Unknown
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.CreatedAt).NotEmpty();
        RuleFor(sale => sale.Customer)
            .MinimumLength(3).WithMessage("Customer must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Customer cannot be longer than 50 characters.");
        RuleFor(sale => sale.TotalSaleValue).NotEqual(0);
        RuleFor(sale => sale.BranchForSale)
            .Length(3, 50)
            .MinimumLength(3).WithMessage("BranchForSale must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("BranchForSale cannot be longer than 50 characters.");
    }
}