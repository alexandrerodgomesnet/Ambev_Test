namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Request model for deleting a sale
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>
    public Guid Id { get; set; }
}