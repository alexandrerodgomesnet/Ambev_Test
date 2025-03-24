namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Request;

public class SaleRequest
{
    public string Customer { get; set; } = string.Empty;
    public string BranchForSale { get; set; } = string.Empty;
    public List<ItemSaleRequest> Products { get; set; } = [];
}