using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Application.Sales.Rules;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale, 
/// including NumberSale, CreatedAt, Customer, TotalSaleValue, BranchForSale, Products and Status. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : ICommand<CreateSaleResult>
{
    public CreateSaleCommand()
    {
        Status = SaleStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets or sets the CreatedAt for the sale.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the Customer for the sale.
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the TotalSaleValue for the sale.
    /// </summary>
    public decimal TotalSaleValue { get; set; }

    /// <summary>
    /// Gets or sets the BranchForSale for the sale.
    /// </summary>
    public string BranchForSale { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Products for the sale.
    /// </summary>

    public List<ItemSale> Products { get; set; } = [];

    /// <summary>
    /// Gets or sets the Status for the sale.
    /// </summary>
    public SaleStatus Status { get; set; }

    public void MakeDiscount()
    {
        foreach (var product in Products)
        {
            var calculateDiscount = new CalculateDiscount();
            product.SetTotalItemValue(calculateDiscount.Calculate(product) ?? 0);
        }
        TotalSaleValue = Products.Sum(x => x.TotalItemValue);
    }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}