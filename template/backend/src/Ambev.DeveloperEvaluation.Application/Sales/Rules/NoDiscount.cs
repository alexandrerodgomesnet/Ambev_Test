using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Rules;

public class NoDiscount : ICalculateDiscount
{
    public decimal? Aplly(ItemSale itemSale) => 0;

    public void SetNext(ICalculateDiscount discount) { }
}