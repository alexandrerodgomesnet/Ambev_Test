using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Rules;

public interface IDiscount
{
    decimal? Calculate(ItemSale itemSale);
}