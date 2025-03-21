using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Rules;

public interface ICalculateDiscount
{
    decimal? Aplly(ItemSale itemSale);
    void SetNext(ICalculateDiscount discount);
}