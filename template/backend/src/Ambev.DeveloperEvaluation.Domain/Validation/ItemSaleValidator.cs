using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ItemSaleValidator : AbstractValidator<ItemSale>
{
    public ItemSaleValidator()
    {
        RuleFor(item => item.Title)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Title sale must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Title sale cannot be longer than 50 characters.");

        RuleFor(item => item.Quantity)
            .NotEqual(0)
            .WithMessage("Quantity of items cannot be equal to zero.");

        RuleFor(sale => sale.UnitPrice)
            .NotEqual(0)
            .WithMessage("Unit price cannot be equal to zero");
    }
}