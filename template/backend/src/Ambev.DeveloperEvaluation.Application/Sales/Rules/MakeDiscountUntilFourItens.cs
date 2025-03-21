using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Rules;

public class MakeDiscountUntilFourItens : ICalculateDiscount
{
    private ICalculateDiscount? _discount;
    public decimal? Aplly(ItemSale itemSale)
    {
        if(itemSale.Quantity < 4)
            return  itemSale.UnitPrice * itemSale.Quantity;
        
        return _discount?.Aplly(itemSale);
    }

    public void SetNext(ICalculateDiscount discount) => _discount = discount;
}