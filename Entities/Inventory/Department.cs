using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Inventory;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
}
