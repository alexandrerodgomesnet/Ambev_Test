using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Updated a sale in the database
    /// </summary>
    /// <param name="sale">The sale to updated</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale</returns>
    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var existingSale = await _context.Sales
            .AsNoTracking()
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == sale.Id, cancellationToken)
            ?? throw new InvalidOperationException($"Sale with id {sale.Id} does not exist.");

        _context.Sales.Attach(sale);
        await UpdateItemSales(sale.Products, existingSale.Products);
        _context.Entry(sale).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    private async Task UpdateItemSales(List<ItemSale> newProducts, List<ItemSale> productsDb)
    {
        foreach (var productDb in productsDb)
        {
            var newProduct = newProducts.FirstOrDefault(p => p.Id == productDb.Id);

            if(newProduct != null)
            {
                _context.ItemSales.Attach(newProduct!);
                _context.Entry(newProduct).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Sales
            .Include(x => x.Products)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    /// <summary>
    /// Retrieves a sale by their numberSale
    /// </summary>
    /// <param name="numberSale">The numberSale to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByNumberSaleAsync(int numberSale, CancellationToken cancellationToken = default)
        => await _context.Sales
            .Include(x => x.Products)
            .FirstOrDefaultAsync(s => s.NumberSale == numberSale 
                && s.Status == SaleStatus.Active, cancellationToken);

    /// <summary>
    /// Retrieves a sale by their numberSale
    /// </summary>
    /// <param name="numberSale">The numberSale to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByCustomerAsync(string customer, CancellationToken cancellationToken = default)
        => await _context.Sales
            .Include(x => x.Products)
            .FirstOrDefaultAsync(s => s.Customer.Equals(customer, StringComparison.CurrentCultureIgnoreCase)
                && s.Status == SaleStatus.Active, cancellationToken);

    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
