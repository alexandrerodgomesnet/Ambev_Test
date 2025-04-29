using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Common.Rules.Discount;

public interface IDiscount
{
    decimal? Calculate(ItemSale itemSale);
}