
namespace Centraly.Api.Entities.Inventory;

public class ProductProperty : BaseEntity
{
    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}