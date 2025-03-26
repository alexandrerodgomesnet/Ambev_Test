using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales;

/// <summary>
/// Validator for GetSaleQuery
/// </summary>
public class GetSaleQueryValidator : AbstractValidator<GetSaleQuery>
{
    /// <summary>
    /// Initializes validation rules for GetSaleQuery
    /// </summary>
    public GetSaleQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
