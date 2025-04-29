using Ambev.DeveloperEvaluation.Domain.Common.Rules.Discount;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ProductList : List<ItemSale>
{
    public decimal MakeDiscount()
    {
        ForEach(product =>
        {
            var calculateDiscount = new CalculateDiscount();
            product.SetTotalItemValue(calculateDiscount.Calculate(product) ?? 0);
        });

        return this.Sum(x => x.TotalItemValue);
    }
}
