using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales;

/// <summary>
/// Handler for processing DeleteSaleCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IValidator<DeleteSaleCommand> _validator;

    /// <summary>
    /// Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="validator">The validator for DeleteSaleCommand</param>
    public DeleteSaleHandler(ISaleRepository saleRepository,
        IValidator<DeleteSaleCommand> validator) 
    {
        _saleRepository = saleRepository;
        _validator = validator;
    }
    
    /// <summary>
    /// Handles the DeleteSaleCommand request
    /// </summary>
    /// <param name="request">The DeleteSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"User with ID {request.Id} not found");

        return new DeleteSaleResponse { Success = true };
    }
}