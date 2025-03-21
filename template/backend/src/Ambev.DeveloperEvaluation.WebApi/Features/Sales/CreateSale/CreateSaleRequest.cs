using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CreateSale.Sales;

public class CreateSaleRequest
{
    public string Customer { get; set; } = string.Empty;
    public string BranchForSale { get; set; } = string.Empty;
    public List<ItemSale> Products { get; set; } = [];

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleRequestValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

// public sealed record CreateSaleRequest (
//     string Customer,
//     string BranchForSale,
//     IEnumerable<ItemSale> Products
// )
// {
//     public ValidationResultDetail Validate()
//     {
//         var validator = new CreateSaleRequestValidator();
//         var result = validator.Validate(this);
//         return new ValidationResultDetail
//         {
//             IsValid = result.IsValid,
//             Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
//         };
//     }
// }