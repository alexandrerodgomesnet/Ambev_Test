using Ambev.DeveloperEvaluation.Common.Results;
using Ambev.DeveloperEvaluation.Common.Results.Extensions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Result<Sale>> CreateAsync(Result<Sale> sale, CancellationToken cancellationToken = default)
    {
        return await sale.TryCatchAsync(async s =>
        {
            await _context.Sales.AddAsync(s, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return s;
        }, "An unknown error occurred while creating the sale.");
        //try
        //{
        //    await _context.Sales.AddAsync(sale.Value, cancellationToken);
        //    await _context.SaveChangesAsync(cancellationToken);
        //    return Result.Success(sale.Value);
        //}
        //catch(Exception ex)
        //{
        //    return Result
        //        .Failure<Sale>(
        //            Error
        //                .Exception($"An unknown error occurred while creating the sale. Error: {ex.Message}")
        //        );
        //}
    }
    public async Task<Result<Sale>> UpdateAsync(Result<Sale> sale, CancellationToken cancellationToken = default)
    {
        var existingSale = await _context.Sales
            .AsNoTracking()
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == sale.Value.Id, cancellationToken)
            ?? throw new InvalidOperationException($"Sale with id {sale.Value.Id} does not exist.");

        _context.Sales.Attach(sale.Value);
        await UpdateItemSales(sale.Value.Products, existingSale.Products);
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
    public async Task<Result<Sale>?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Sales
            .Include(x => x.Products)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    public async Task<Result<Sale>?> GetByNumberSaleAsync(int numberSale, CancellationToken cancellationToken = default)
        => await _context.Sales
            .Include(x => x.Products)
            .FirstOrDefaultAsync(s => s.NumberSale == numberSale 
                && s.Status == SaleStatus.Active, cancellationToken);
    public async Task<Result<Sale>?> GetByCustomerAsync(string customer, CancellationToken cancellationToken = default)
        => await _context.Sales
            .Include(x => x.Products)
            .FirstOrDefaultAsync(s => s.Customer.Equals(customer, StringComparison.CurrentCultureIgnoreCase)
                && s.Status == SaleStatus.Active, cancellationToken);
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale.Value);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
