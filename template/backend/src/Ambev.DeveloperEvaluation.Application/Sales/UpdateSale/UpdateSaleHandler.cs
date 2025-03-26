using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales;

/// <summary>
/// Handler for processing UpdateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : ICommandHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateSaleCommand> _validator;

    /// <summary>
    /// Initializes a new instance of UpdateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateSaleCommand</param>
    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper,
        IValidator<UpdateSaleCommand> validator)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _validator = validator;
    } 

    /// <summary>
    /// Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="command">The UpdateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale details</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken) 
            ?? throw new InvalidOperationException($"Sale with id {command.Id} does not exist.");

        var sale = _mapper.Map<Sale>(command);

        var updatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
        var result = _mapper.Map<UpdateSaleResult>(updatedSale);
        return result;
    }

}