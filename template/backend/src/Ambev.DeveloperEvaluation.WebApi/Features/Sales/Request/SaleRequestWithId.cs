namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Request;

public class SaleRequestWithId
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Customer { get; set; } = string.Empty;
    public string BranchForSale { get; set; } = string.Empty;
    public List<ItemSaleRequestWithId> Products { get; set; } = [];
}