using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class CreateSaleCommand : ICommandResult<CreateSaleResult>
{
    private CreateSaleCommand(string customer, string branchForSale, ProductList products)
    {
        Customer = customer;
        BranchForSale = branchForSale;
        Products = products;        
        TotalSaleValue = products.MakeDiscount();
        Status = SaleStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    public static CreateSaleCommand Create(string customer, string branchForSale, ProductList products) =>
        new (customer, branchForSale, products);

    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; } = string.Empty;
    public ProductList Products { get; set; }
    public decimal TotalSaleValue { get; set; }
    public string BranchForSale { get; set; } = string.Empty;
    public SaleStatus Status { get; set; }

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