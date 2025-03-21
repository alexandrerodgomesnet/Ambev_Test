using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Rules;

public class MakeDiscountBetweenFourAndTenItems : ICalculateDiscount
{
    private ICalculateDiscount? _discount;
    public decimal? Aplly(ItemSale itemSale)
    {
        if(itemSale.Quantity > 4 && itemSale.Quantity < 10)
        {
            itemSale.SetDiscount(10);
            return (itemSale.UnitPrice * itemSale.Quantity) * itemSale.Discount;
        } 
        
        return _discount?.Aplly(itemSale);
    }

    public void SetNext(ICalculateDiscount discount) => _discount = discount;
}