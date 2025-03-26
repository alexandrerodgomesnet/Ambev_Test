using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;

namespace Ambev.DeveloperEvaluation.Application.Sales;

/// <summary>
/// Command for retrieving a sale by their ID
/// </summary>
public record GetSaleQuery : ICommand<GetSaleResult>
{
    /// <summary>
    /// The unique identifier of the sale to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleQuery
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve</param>
    public GetSaleQuery(Guid id)
    {
        Id = id;
    }
}