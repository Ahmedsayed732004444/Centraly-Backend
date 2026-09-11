using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Returns;

public class ReturnItem : BaseEntity
{
    public string ReturnRecordId { get; set; } = string.Empty;
    public ReturnRecord? ReturnRecord { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string BatchId { get; set; } = string.Empty;
    public ProductBatch? Batch { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

