using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Common.Rules.Discount;

public class MakeDiscountBetweenTenAndTwentyItems : ICalculateDiscount
{
    private ICalculateDiscount? _discount;
    public decimal? Aplly(ItemSale itemSale)
    {
        if(itemSale.Quantity > 10 && itemSale.Quantity <= 20)
        {
            itemSale.SetDiscount(20);
            return itemSale.UnitPrice * itemSale.Quantity * itemSale.Discount;
        }            
        
        return _discount?.Aplly(itemSale);
    }

    public void SetNext(ICalculateDiscount discount) => _discount = discount;
}