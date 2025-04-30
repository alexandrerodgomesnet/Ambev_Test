using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated Sale will have valid:
    /// - Customer (using internet usernames)
    /// - BranchForSale (using internet usernames)
    /// - Status (Active or Canceled)
    /// - Products (meeting complexity requirements)
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(u => u.NumberSale, f => f.Random.Number(100, 999))
        .RuleFor(u => u.Customer, f => f.Internet.UserName())
        .RuleFor(u => u.TotalSaleValue, f => f.Random.Decimal(100, 999))
        .RuleFor(u => u.BranchForSale, f => f.Internet.UserName())
        .RuleFor(u => u.Status, f => f.PickRandom(SaleStatus.Active, SaleStatus.Canceled))
        .RuleFor(u => u.Products, f => ItemSaleTestData.GenerateProducts());

    /// <summary>
    /// Generates a valid sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale() => SaleFaker.Generate();

    /// <summary>
    /// Generates a BranchForSale that exceeds the maximum length limit.
    /// The generated BranchForSale will:
    /// - Be longer than 50 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing BranchForSale length validation error cases.
    /// </summary>
    /// <returns>A BranchForSale that exceeds the maximum length limit.</returns>
    public static string GenerateInvalidBranchForSale() => new Faker().Random.String2(51);
    
    /// <summary>
    /// Generates a Customer that exceeds the maximum length limit.
    /// The generated Customer will:
    /// - Be longer than 50 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing Customer length validation error cases.
    /// </summary>
    /// <returns>A Customer that exceeds the maximum length limit.</returns>
    public static string GenerateInvalidCustomer() => new Faker().Random.String2(51);
        
    /// <summary>
    /// Generates an invalid product list
    /// The generated Product list will:
    /// - Be empty
    /// This is useful for testing Product list validation error cases.
    /// </summary>
    /// <returns>An empty list of product items.</returns>
    public static ProductList GenerateInvalidProducts() => [];

    /// <summary>
    /// Generates an invalid status
    /// The generated status will:
    /// - Be Unknown
    /// This is useful for testing Status validation error cases.
    /// </summary>
    /// <returns>An unknown status.</returns>
    public static SaleStatus GenerateInvalidStatus() => SaleStatus.Unknown;

    /// <summary>
    /// Generates a sale with invalid customer length
    /// </summary>
    public static Sale GenerateSaleWithInvalidCustomer() => 
        SaleFaker.Clone()
            .RuleFor(s => s.Customer, _ => GenerateInvalidCustomer())
            .Generate();

    /// <summary>
    /// Generates a sale with invalid branch length
    /// </summary>
    public static Sale GenerateSaleWithInvalidBranch() => 
        SaleFaker.Clone()
            .RuleFor(s => s.BranchForSale, _ => GenerateInvalidBranchForSale())
            .Generate();

    /// <summary>
    /// Generates a sale with invalid status
    /// </summary>
    public static Sale GenerateSaleWithInvalidStatus() => 
        SaleFaker.Clone()
            .RuleFor(s => s.Status, _ => GenerateInvalidStatus())
            .Generate();

    /// <summary>
    /// Generates a sale with invalid products
    /// </summary>
    public static Sale GenerateSaleWithInvalidProducts() => 
        SaleFaker.Clone()
            .RuleFor(s => s.Products, _ => GenerateInvalidProducts())
            .Generate();
}
