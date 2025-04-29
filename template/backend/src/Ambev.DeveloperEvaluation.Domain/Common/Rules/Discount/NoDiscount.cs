using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Common.Rules.Discount;

public class NoDiscount : ICalculateDiscount
{
    public decimal? Aplly(ItemSale itemSale) => 0;

    public void SetNext(ICalculateDiscount discount) { }
}