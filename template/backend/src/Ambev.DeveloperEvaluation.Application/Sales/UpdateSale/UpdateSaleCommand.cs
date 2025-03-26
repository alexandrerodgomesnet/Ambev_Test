using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Application.Sales.Rules;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class UpdateSaleCommand: ICommand<UpdateSaleResult>
{
    public UpdateSaleCommand()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public UpdateSaleCommand(Guid id, string customer, string branchForSale, 
        List<ItemSale> products) : this()
    {
        Id = id;
        Customer = customer;
        BranchForSale = branchForSale;
        Products = products;
    }

    /// <summary>
    /// The unique identifier of the sale to retrieve
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the UpdatedAt for the sale.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

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


    public void MakeDiscount()
    {
        foreach (var product in Products)
        {
            var calculateDiscount = new CalculateDiscount();
            product.SetTotalItemValue(calculateDiscount.Calculate(product) ?? 0);
        }
        TotalSaleValue = Products.Sum(x => x.TotalItemValue);
    }
}