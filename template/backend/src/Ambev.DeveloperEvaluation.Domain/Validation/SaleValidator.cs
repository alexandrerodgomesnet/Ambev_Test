using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.Customer)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Customer must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Customer cannot be longer than 50 characters.");

        RuleFor(sale => sale.BranchForSale)
            .NotEmpty()
            .MinimumLength(3).WithMessage("BranchForSale must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("BranchForSale cannot be longer than 50 characters.");

        RuleFor(sale => sale.Products)
            .NotEmpty()
            .WithMessage("Products on sale cannot be empty");

        RuleFor(sale => sale.Status)
            .NotEqual(SaleStatus.Unknown)
            .WithMessage("Sale status cannot be Unknown.");
    }
}