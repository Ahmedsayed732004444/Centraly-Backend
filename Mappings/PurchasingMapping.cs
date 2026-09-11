using Centraly.Api.Contracts.Inventory.Products;
using Centraly.Api.Contracts.Suppliers;
using Centraly.Api.Entities.Inventory;
using Centraly.Api.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class PurchasingMapping
{
    // ─────────────────────────────────────────────────────────────────
    //  Suppliers
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SupplierResponse> ProjectToResponse(this IQueryable<Supplier> query)
    {
        return query
            .Where(s => !s.IsDeleted)
            .AsNoTracking()
            .Select(s => new SupplierResponse(
                s.Id,
                s.Name,
                s.Type,
                s.Phone,
                s.Address,
                s.DebtBalance,
                s.PurchaseInvoices.Count(pi => !pi.IsDeleted),
                s.Returns.Count(r => !r.IsDeleted),
                s.CreatedAt));
    }

    public static IQueryable<SupplierBatchResponse> ProjectToResponse(this IQueryable<ProductBatch> query)
    {
        return query
            .Where(b => b.AvailableQuantity > 0 && !b.IsDeleted)
            .AsNoTracking()
            .Select(b => new SupplierBatchResponse(
                b.Id,
                b.ProductId,
                b.Product != null ? b.Product.Name : null,
                b.Product != null ? b.Product.Barcode : null,
                b.AvailableQuantity,
                b.PurchasePrice,
                b.DateReceived));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Purchase Invoices
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<PurchaseInvoiceResponse> ProjectToResponse(this IQueryable<PurchaseInvoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new PurchaseInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                new SupplierSummary(i.Supplier!.Id, i.Supplier.Name, i.Supplier.Phone),
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.InvoiceDate,
                i.Notes,
                i.Items.Select(item => new PurchaseInvoiceItemResponse(
                    item.Id,
                    new ProductSummary(item.ProductId, item.Product!.Name, item.Product.Barcode, item.Product.ImageUrl, 0, 0, item.Product.Quantity),
                    item.Quantity,
                    item.UnitCost,
                    item.Quantity * item.UnitCost))
                    .ToList()));
    }

    public static IQueryable<PurchaseInvoiceResponse> ProjectToSummaryResponse(this IQueryable<PurchaseInvoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new PurchaseInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                new SupplierSummary(i.Supplier!.Id, i.Supplier.Name, i.Supplier.Phone),
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.InvoiceDate,
                i.Notes,
                new List<PurchaseInvoiceItemResponse>()));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Supplier Payments
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SupplierPaymentResponse> ProjectToResponse(this IQueryable<SupplierPayment> query)
    {
        return query
            .Where(p => !p.IsDeleted)
            .AsNoTracking()
            .Select(p => new SupplierPaymentResponse(
                p.Id,
                new SupplierSummary(p.Supplier!.Id, p.Supplier.Name, p.Supplier.Phone),
                p.Amount,
                p.PaymentDate,
                p.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Supplier Returns
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SupplierReturnResponse> ProjectToResponse(this IQueryable<SupplierReturn> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new SupplierReturnResponse(
                r.Id,
                new SupplierSummary(r.Supplier!.Id, r.Supplier.Name, r.Supplier.Phone),
                (ReturnReasonDto)r.Reason,
                r.Notes,
                r.TotalReturnedAmount,
                r.ReturnDate,
                r.Items.Select(item => new SupplierReturnItemResponse(
                    item.Id,
                    new ProductSummary(item.ProductId, item.Product!.Name, item.Product.Barcode, item.Product.ImageUrl, 0, 0, item.Product.Quantity),
                    item.Quantity,
                    item.UnitCost,
                    item.Quantity * item.UnitCost))
                    .ToList(),
                r.Items.Count));
    }

    public static IQueryable<SupplierReturnResponse> ProjectToSummaryResponse(this IQueryable<SupplierReturn> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new SupplierReturnResponse(
                r.Id,
                new SupplierSummary(r.Supplier!.Id, r.Supplier.Name, r.Supplier.Phone),
                (ReturnReasonDto)r.Reason,
                r.Notes,
                r.TotalReturnedAmount,
                r.ReturnDate,
                new List<SupplierReturnItemResponse>(),
                r.Items.Count));
    }
}
