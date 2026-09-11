namespace Centraly.Api.Services.Implementation;

public class ProductService(
    ApplicationDbContext _dbContext,
    IWebHostEnvironment _env,
    IHttpContextAccessor _accessor,
    ILogger<ProductService> _logger,
    INotificationService _notificationService) : IProductService
{
    public async Task<Result<ProductResponse>> AddProductAsync(CreateProductRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var departmentExists = await _dbContext.Departments.AnyAsync(d => d.Id == request.DepartmentId && !d.IsDeleted, ct);
            if (!departmentExists) return Result.Failure<ProductResponse>(ProductErrors.DepartmentNotFound);

            var category = await _dbContext.Categories
                .Where(c => c.Id == request.CategoryId && c.DepartmentId == request.DepartmentId && !c.IsDeleted)
                .FirstOrDefaultAsync(ct);

            if (category is null) return Result.Failure<ProductResponse>(ProductErrors.CategoryNotFound);

            if (!string.IsNullOrWhiteSpace(request.Barcode))
            {
                var barcodeExists = await _dbContext.Products.AnyAsync(p => p.Barcode == request.Barcode && !p.IsDeleted, ct);
                if (barcodeExists) return Result.Failure<ProductResponse>(ProductErrors.BarcodeAlreadyExists);
            }

            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Barcode = request.Barcode,
                Name = request.Name,
                DepartmentId = request.DepartmentId,
                CategoryId = request.CategoryId,
                Quantity = 0, // Opens with 0, requires Purchase Invoice
                MinQuantityAlert = request.MinQuantityAlert,
                StorageLocation = request.StorageLocation,
                Usage = (ProductUsage)request.Usage,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            if (request.Image is not null)
            {
                product.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/products", _env, _accessor);
            }

            if (request.Properties is not null && request.Properties.Any())
            {
                foreach (var prop in request.Properties)
                {
                    product.Properties.Add(new ProductProperty
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = prop.Key,
                        Value = prop.Value,
                        CreatedAt = DateTime.UtcNow,
                        CreatedByUserId = userId
                    });
                }
            }

            await _dbContext.Products.AddAsync(product, ct);
            await _dbContext.SaveChangesAsync(ct);

            return await GetProductAsync(product.Id, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a product");
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<ProductResponse>> GetProductAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var productProjection = await _dbContext.Products
                .Where(p => p.Id == id)
                .ProjectToIntermediate()
                .FirstOrDefaultAsync(ct);

            if (productProjection is null)
                return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);

            return Result.Success(productProjection.ToResponse());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving product {ProductId}", id);
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<PaginatedList<ProductResponse>>> GetAllProductsAsync(RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Products
                .AsNoTracking()
                .Where(p => !p.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.SearchValue))
            {
                string search = filters.SearchValue.Trim().ToLower();
                query = query.Where(p => p.Name!.ToLower().Contains(search) || (p.Barcode != null && p.Barcode.Contains(search)));
            }

            if (!string.IsNullOrWhiteSpace(filters.CategoryId))
            {
                query = query.Where(p => p.CategoryId == filters.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(filters.DepartmentId))
            {
                query = query.Where(p => p.DepartmentId == filters.DepartmentId);
            }

            if (!string.IsNullOrWhiteSpace(filters.StockStatus))
            {
                if (filters.StockStatus.Equals("OutOfStock", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(p => p.Quantity <= 0);
                }
                else if (filters.StockStatus.Equals("LowStock", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(p => p.Quantity > 0 && p.Quantity <= p.MinQuantityAlert);
                }
                else if (filters.StockStatus.Equals("InStock", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(p => p.Quantity > p.MinQuantityAlert);
                }
            }

            // Fixed Usage filter mapping based on Claude's analysis
            if (filters.Usage.HasValue)
            {
                query = query.Where(p => p.Usage == (ProductUsage)filters.Usage.Value);
            }
            if (filters.ExcludeUsage.HasValue)
            {
                query = query.Where(p => p.Usage != (ProductUsage)filters.ExcludeUsage.Value);
            }

            var totalCount = await query.CountAsync(ct);

            query = filters.SortDirection == SortDirection.Desc
                 ? query.OrderByDescending(p => p.CreatedAt).ThenBy(p => p.Id)
                 : query.OrderBy(p => p.CreatedAt).ThenBy(p => p.Id);

            var pagedProductIds = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .Select(p => p.Id)
                .ToListAsync(ct);

            var projections = await _dbContext.Products
                .Where(p => pagedProductIds.Contains(p.Id))
                .ProjectToIntermediate()
                .ToListAsync(ct);

            var responses = projections
                .OrderBy(p => pagedProductIds.IndexOf(p.ProductId))
                .Select(p => p.ToResponse())
                .ToList();

            return Result.Success(new PaginatedList<ProductResponse>(responses, filters.PageNumber, filters.PageSize, totalCount));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving products");
            return Result.Failure<PaginatedList<ProductResponse>>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<List<ProductSupplierResponse>>> GetProductSuppliersAsync(string productId, CancellationToken ct = default)
    {
        try
        {
            var productExists = await _dbContext.Products.AnyAsync(p => p.Id == productId && !p.IsDeleted, ct);
            if (!productExists) return Result.Failure<List<ProductSupplierResponse>>(ProductErrors.ProductNotFound);

            var batches = await _dbContext.ProductBatches
                .Include(b => b.Supplier)
                .Where(b => b.ProductId == productId && !b.IsDeleted)
                .Select(b => new
                {
                    b.SupplierId,
                    SupplierName = b.Supplier!.Name,
                    b.PurchasePrice,
                    b.InitialQuantity,
                    b.DateReceived
                })
                .ToListAsync(ct);

            var result = batches
                .Where(x => x.SupplierId != null)
                .GroupBy(x => new { x.SupplierId, x.SupplierName })
                .Select(g => new ProductSupplierResponse(
                    g.Key.SupplierId!,
                    g.Key.SupplierName,
                    g.OrderByDescending(x => x.DateReceived).First().PurchasePrice,
                    g.Max(x => x.DateReceived),
                    g.Sum(x => x.InitialQuantity)
                ))
                .OrderByDescending(x => x.LastPurchaseDate)
                .ToList();

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving suppliers for product {ProductId}", productId);
            return Result.Failure<List<ProductSupplierResponse>>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<ProductResponse>> UpdateProductAsync(string id, UpdateProductRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var product = await _dbContext.Products
                .Include(p => p.Properties)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, ct);

            if (product is null) return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);

            if (product.DepartmentId != request.DepartmentId)
            {
                var departmentExists = await _dbContext.Departments.AnyAsync(d => d.Id == request.DepartmentId && !d.IsDeleted, ct);
                if (!departmentExists) return Result.Failure<ProductResponse>(ProductErrors.DepartmentNotFound);
                product.DepartmentId = request.DepartmentId;
            }

            if (product.CategoryId != request.CategoryId)
            {
                var categoryExists = await _dbContext.Categories.AnyAsync(c => c.Id == request.CategoryId && !c.IsDeleted, ct);
                if (!categoryExists) return Result.Failure<ProductResponse>(ProductErrors.CategoryNotFound);
                product.CategoryId = request.CategoryId;
            }

            if (!string.IsNullOrWhiteSpace(request.Barcode) && request.Barcode != product.Barcode)
            {
                var barcodeExists = await _dbContext.Products.AnyAsync(p => p.Barcode == request.Barcode && p.Id != id && !p.IsDeleted, ct);
                if (barcodeExists) return Result.Failure<ProductResponse>(ProductErrors.BarcodeAlreadyExists);
            }

            product.Barcode = request.Barcode;
            product.Name = request.Name;
            product.MinQuantityAlert = request.MinQuantityAlert;
            product.StorageLocation = request.StorageLocation;
            product.Usage = (ProductUsage)request.Usage;

            if (request.Image is not null)
            {
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    FileHelper.DeleteFile(product.ImageUrl, "uploads/products", _env);
                }
                product.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/products", _env, _accessor);
            }

            if (request.Properties is not null)
            {
                _dbContext.ProductProperties.RemoveRange(product.Properties);
                foreach (var prop in request.Properties)
                {
                    product.Properties.Add(new ProductProperty
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = prop.Key,
                        Value = prop.Value,
                        CreatedAt = DateTime.UtcNow,
                        CreatedByUserId = userId
                    });
                }
            }

            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedByUserId = userId;

            await _dbContext.SaveChangesAsync(ct);
            return await GetProductAsync(product.Id, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating product {ProductId}", id);
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<ProductResponse>> AdjustQuantityAsync(
        string id, AdjustProductQuantityRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, ct);

            if (product is null) return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);

            if (request.NewQuantity < 0) return Result.Failure<ProductResponse>(ProductErrors.NegativeQuantity);

            int diff = request.NewQuantity - product.Quantity;
            if (diff != 0)
            {
                // Fix for Claude issue 1.4: Instead of just changing Product.Quantity, we add an adjustment batch
                // to maintain perfect sync with the Batches system.
                var adjustmentBatch = new ProductBatch
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = id,
                    InitialQuantity = diff,
                    AvailableQuantity = diff, // Handles both positive (surplus) and negative (loss/shrinkage)
                    PurchasePrice = 0,
                    WholesalePrice = 0,
                    RetailPrice = 0,
                    MaintenancePrice = 0,
                    DateReceived = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = userId
                };
                await _dbContext.ProductBatches.AddAsync(adjustmentBatch, ct);
            }

            var qtyBeforeAdjustment = product.Quantity;
            product.Quantity = request.NewQuantity;
            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedByUserId = userId;

            await _dbContext.SaveChangesAsync(ct);
            await _notificationService.NotifyStockChangeAsync(product, qtyBeforeAdjustment, ct);
            return await GetProductAsync(id, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adjusting quantity for product {ProductId}", id);
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<bool>> DeleteProductAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var quantity = await _dbContext.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => (int?)p.Quantity)
                .FirstOrDefaultAsync(ct);

            if (quantity is null) return Result.Failure<bool>(ProductErrors.ProductNotFound);
            if (quantity != 0) return Result.Failure<bool>(ProductErrors.CannotDeleteWithStock);

            // Improved Delete utilizing ExecuteUpdateAsync (Issue 2.2)
            var rowsAffected = await _dbContext.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.IsDeleted, true)
                    .SetProperty(p => p.DeletedAt, DateTime.UtcNow), ct);

            if (rowsAffected == 0) return Result.Failure<bool>(ProductErrors.ProductNotFound);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting product {ProductId}", id);
            return Result.Failure<bool>(ProductErrors.ProductNotFound);
        }
    }
}
