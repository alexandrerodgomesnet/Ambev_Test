using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class UpdateSaleCommand: ICommandResult<UpdateSaleResult>
{
    private UpdateSaleCommand(Guid id, string customer, string branchForSale, ProductList products)
    {
        Id = id;
        Customer = customer;
        BranchForSale = branchForSale;
        Products = products;
        TotalSaleValue = products.MakeDiscount();
        UpdatedAt = DateTime.UtcNow;
    }

    public static UpdateSaleCommand Create(Guid id, string customer, string branchForSale, ProductList products) =>
        new(id, customer, branchForSale, products);

    public Guid Id { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string Customer { get; private set; } = string.Empty;
    public decimal TotalSaleValue { get; private set; }
    public string BranchForSale { get; private set; } = string.Empty;
    public ProductList Products { get; private set; } = [];
}