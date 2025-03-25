using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

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
        RuleFor(sale => sale.Customer)
            .NotEmpty().WithMessage("Customer is required.")
            .MinimumLength(3).WithMessage("Customer must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Customer cannot be longer than 50 characters.");

        RuleFor(sale => sale.BranchForSale)
            .NotEmpty().WithMessage("BranchForSale is required.")
            .MinimumLength(3).WithMessage("BranchForSale must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("BranchForSale cannot be longer than 50 characters.");

        RuleForEach(x => x.Products)
            .ChildRules(itemSale => {
                
                itemSale.RuleFor(item => item.Title)
                    .NotEmpty()
                    .WithMessage("Title is required.")
                    .MinimumLength(3)
                    .WithMessage("Title sale must be at least 3 characters long.")
                    .MaximumLength(50)
                    .WithMessage("Title sale cannot be longer than 50 characters.");

                itemSale.RuleFor(item => item.Quantity)
                    .Must(QuantityGreaterThanOrEqualTo1AndLessThanOrEqualTo20)
                    .WithMessage("The quantity must be between 1 and 20 items.");

                itemSale.RuleFor(sale => sale.UnitPrice)
                    .NotEqual(0)
                    .WithMessage("Unit price cannot be equal to zero");
        });
    }

    public static bool QuantityGreaterThanOrEqualTo1AndLessThanOrEqualTo20(int quantity) =>
        quantity >= 1 && quantity <= 20;
}