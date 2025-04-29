using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Common.Rules.Discount;

public class CalculateDiscount : IDiscount
{
    public decimal? Calculate(ItemSale itemSale)
    {
        var discount10_20_itens = new MakeDiscountBetweenTenAndTwentyItems();
        var discount4_10_itens = new MakeDiscountBetweenFourAndTenItems();
        var discountUntilFourItens = new MakeDiscountUntilFourItens();
        var noDiscount = new NoDiscount();

        discount10_20_itens.SetNext(discount4_10_itens);
        discount4_10_itens.SetNext(discountUntilFourItens);
        discountUntilFourItens.SetNext(noDiscount);

        return discount10_20_itens?.Aplly(itemSale);
    }
}