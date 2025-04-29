using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Common.Rules.Discount;

public interface ICalculateDiscount
{
    decimal? Aplly(ItemSale itemSale);
    void SetNext(ICalculateDiscount discount);
}