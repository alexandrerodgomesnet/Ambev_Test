using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTest
{
    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that when a not cancelled sale is activated, their status changes to cancelled.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to not cancelled when activated")]
    public void Given_NotCancelled_Sale_When_Activated_Then_Status_ShouldBeCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Status = SaleStatus.Canceled;

        // Act
        sale.NotCancelled();

        // Assert
        Assert.Equal(SaleStatus.Active, sale.Status);
    }

    /// <summary>
    /// Tests that when a cancelled sale is activated, their status changes to not cancelled.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to cancelled when activated")]
    public void Given_Cancelled_Sale_When_Activated_Then_Status_ShouldBeNotCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Status = SaleStatus.Active;

        // Act
        sale.Cancelled();

        // Assert
        Assert.Equal(SaleStatus.Canceled, sale.Status);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_Invalid_Sale_Data_When_Validated_Then_Should_Return_Invalid()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = SaleTestData.GenerateInvalidCustomer(),
            BranchForSale = SaleTestData.GenerateInvalidBranchForSale(),
            Products = SaleTestData.GenerateInvalidProducts(),
            Status = SaleTestData.GenerateInvalidStatus()
        };

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}