using Ambev.DeveloperEvaluation.Common.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Result<Sale>> CreateAsync(Result<Sale> sale, CancellationToken cancellationToken = default);
    Task<Result<Sale>> UpdateAsync(Result<Sale> sale, CancellationToken cancellationToken = default);
    Task<Result<Sale>?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<Sale>?> GetByNumberSaleAsync(int numberSale, CancellationToken cancellationToken = default);
    Task<Result<Sale>?> GetByCustomerAsync(string customer, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}