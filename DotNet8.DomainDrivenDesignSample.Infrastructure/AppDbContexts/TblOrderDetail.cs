namespace DotNet8.DomainDrivenDesignSample.Infrastructure.AppDbContexts;

public partial class TblOrderDetail
{
    public string OrderDetailId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal PricePerItem { get; set; }
}
