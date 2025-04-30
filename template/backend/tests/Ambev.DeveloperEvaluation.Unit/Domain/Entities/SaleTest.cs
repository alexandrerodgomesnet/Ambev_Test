using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover validation, status changes, and business rules.
/// </summary>
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
    /// Tests that when a cancelled sale is activated, their status changes to active.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to active when not cancelled")]
    public void Given_CancelledSale_When_NotCancelled_Then_StatusShouldBeActive()
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
    /// Tests that when an active sale is cancelled, their status changes to cancelled.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to cancelled when cancelled")]
    public void Given_ActiveSale_When_Cancelled_Then_StatusShouldBeCancelled()
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
    /// Tests that validation fails when customer name is invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid customer name")]
    public void Given_InvalidCustomerName_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithInvalidCustomer();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
        Assert.Contains(result.Errors, e => e.Detail.Contains("Customer"));
    }

    /// <summary>
    /// Tests that validation fails when branch name is invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid branch name")]
    public void Given_InvalidBranchName_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithInvalidBranch();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
        Assert.Contains(result.Errors, e => e.Detail.Contains("BranchForSale"));
    }

    /// <summary>
    /// Tests that validation fails when status is invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid status")]
    public void Given_InvalidStatus_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithInvalidStatus();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
        Assert.Contains(result.Errors, e => e.Detail.Contains("status"));
    }

    /// <summary>
    /// Tests that validation fails when products list is invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid products list")]
    public void Given_InvalidProductsList_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithInvalidProducts();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
        Assert.Contains(result.Errors, e => e.Detail.Contains("Products"));
    }
}