using Microsoft.AspNetCore.Http;
using Centraly.Api.Contracts.Shared.Enums;
namespace Centraly.Api.Contracts.Inventory.Products;

public record CreateProductRequest(
    string? Barcode,
    string? Name,
    string DepartmentId,
    string CategoryId,
    IFormFile? Image,
    int MinQuantityAlert,
    string? StorageLocation,
    ProductUsageDto Usage,
    Dictionary<string, string>? Properties
);