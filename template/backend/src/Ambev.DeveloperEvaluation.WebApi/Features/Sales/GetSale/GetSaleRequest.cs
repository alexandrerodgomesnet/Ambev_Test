using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Request;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Request model for getting a sale by ID
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
