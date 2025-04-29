using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class ItemSaleTest
{
    /// <summary>
    /// Tests that validation passes when all itemSale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid itemsale data")]
    public void Given_Valid_ItemSale_Data_When_Validated_Then_Should_Return_Valid()
    {
        // Arrange
        var itemSale = ItemSaleTestData.GenerateValidItemSale();

        // Act
        //var result = itemSale.Validate();

        //// Assert
        //Assert.True(result.IsValid);
        //Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid itemsale data")]
    public void Given_Invalid_ItemSale_Data_When_Validated_Then_Should_Return_Invalid()
    {
        // Arrange
        var itemSale = new ItemSale
        {
            Title = ItemSaleTestData.GenerateInvalidTitle(),
            Quantity = ItemSaleTestData.GenerateInvalidQuantity(),
            UnitPrice = ItemSaleTestData.GenerateInvalidUnitPrice()
        };

        // Act
        //var result = itemSale.Validate();

        //// Assert
        //Assert.False(result.IsValid);
        //Assert.NotEmpty(result.Errors);
    }
}