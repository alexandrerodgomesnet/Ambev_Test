using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales;

/// <summary>
/// Validator for GetUserCommand
/// </summary>
public class GetSaleCommandValidator : AbstractValidator<GetSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public GetSaleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
