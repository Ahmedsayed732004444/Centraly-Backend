using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Inventory;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Fix: كان string? (اختياري) وده بيسمح بتصنيف من غير قسم - بقى إلزامي
    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}
