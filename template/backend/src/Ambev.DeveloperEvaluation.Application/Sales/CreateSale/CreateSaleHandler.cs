using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Common.Results;
using Ambev.DeveloperEvaluation.Common.Results.Extensions;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class CreateSaleHandler : ICommandResultHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper; 
    }

    //public async Task<Result<CreateSaleResult>> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    //{
    //    var sale = _mapper.Map<Sale>(command);

    //    var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
    //    var result = _mapper.Map<CreateSaleResult>(createdSale);

    //    return result;
    //}

    public async Task<Result<CreateSaleResult>> Handle(CreateSaleCommand command, CancellationToken cancellationToken) =>
        await Result.Create(command)
            .Map(_mapper.Map<Sale>)
            .TapAsync(sale => _saleRepository.CreateAsync(sale, cancellationToken))
            .MapAsync(_mapper.Map<CreateSaleResult>);
}