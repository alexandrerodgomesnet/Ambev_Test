using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class ItemSaleTestData
{
    private static readonly Faker<ItemSale> ItemSaleFaker = new Faker<ItemSale>()
        .RuleFor(u => u.Title, f => f.Internet.UserName())
        .RuleFor(u => u.Quantity, f => f.Random.Number(1, 500))
        .RuleFor(u => u.UnitPrice, f => f.Random.Decimal(1, 100));

    /// <summary>
    /// Generates a list of products.
    /// </summary>
    /// <returns>A valid list ItemSale entity with randomly generated data.</returns>
    public static List<ItemSale> GenerateProducts() =>
        [.. ItemSaleFaker.GenerateLazy(5)];

    /// <summary>
    /// Generates a valid itemsale entity with randomized data.
    /// The generated itemsale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid ItemSale entity with randomly generated data.</returns>
    public static ItemSale GenerateValidItemSale()=> ItemSaleFaker.Generate();
    
    /// <summary>
    /// Generates a quantity equal to zero.
    /// The generated quantity will:
    /// - Cannot be equal to zero.
    /// This is useful for testing quantity length validation error cases.
    /// </summary>
    /// <returns>The value according to the quantity of items in the product list.</returns>
    public static int GenerateInvalidQuantity() => 0;
    
    /// <summary>
    /// Generates a Title that exceeds the maximum length limit.
    /// The generated Title will:
    /// - Be longer than 50 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing Title length validation error cases.
    /// </summary>
    /// <returns>A Title that exceeds the maximum length limit.</returns>
    public static string GenerateInvalidTitle() => new Faker().Random.String2(51);
    
    /// <summary>
    /// Generates the unit value equal to zero.
    /// The generated quantity will:
    /// - Cannot be equal to zero.
    /// This is useful for testing quantity length validation error cases.
    /// </summary>
    /// <returns>The value according to the quantity of items in the product list.</returns>
    public static decimal GenerateInvalidUnitPrice() => 0;
}